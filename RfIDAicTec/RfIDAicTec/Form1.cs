using RfIDAicTec.Models;
using RfIDAicTec.Sheard;
using RFIDReaderAPI;
using RFIDReaderAPI.Interface;
using RFIDReaderAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RfIDAicTec
{

    public delegate void FlushState();                                                        // Update real-time status invoke
    public delegate void AddTag(Tag_Model tag_6C, DataGridViewRow dgvr, Boolean isNew);       // 更新标签信息invoke
    public delegate void WriteDebug(string msg);                                              // 输出调试信息
    public delegate void TCPPortConn(String connID);                                          // 读写器主动连接服务器回调

    public partial class Form1 : Form, IAsynchronousMessage
    {
        Dictionary<String, DataGridViewRow> dic_Rows = new Dictionary<string, DataGridViewRow>(); // 在DataGridView中显示标签数据

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private bool IsFlush = false;                  // 是否继续循环刷新状态（结束刷新线程）
        private bool IsStartRead = false;              // 是否正在读取标签
        private bool IsWriteDebug = false;             // 是否开启DEBUG模式 
        private bool IsShowTag = true;                 // 是否在DataGridView中显示标签数据
        public static Boolean IsEnglish = false;
        private int nowDebugMessageCount = 0;
        List<RoundButton> TJ_List_GPI_Button = new List<RoundButton>();               // GPI灯按钮集合
        List<Tag_Model> tag_ModelsPost = new List<Tag_Model>();
        protected static string XMLFIENAME = "ReaderConfig.xml";
        private bool isConnect = false;
        private string ConnID = "10.84.50.19:9090";
        private eAntennaNo antNo;
        private eReadType readType;
        long TJ_LastTagcount = 0;                       // When reading tags continuously, the total number of tags read in the last second is used to count the real-time rate of tag reading
        public Dictionary<string, string> dic_UsbDevicePath_Name = new Dictionary<string, string>(); //usb设备路径和设备名称字典
        public ReadParam readP = new ReadParam();
        [DllImport("kernel32.dll", EntryPoint = "Beep")]
        //第一个参数是指频率的高低，越大越高，第二个参数是指响的时间多长   
        public static extern int Beep(
        int dwFreq,
        int dwDuration
        );
        #region Reader capability
        public Boolean IsMultiConnect = false;         // 是否是多读写器连接

        private int minDB = 0;                                             // Minimum power
        private int maxDB = 36;                                            // Maximum power
        private int antCount = 2;                                          // Number of antennas
        private List<Int32> bandList = new List<Int32>();                  // Frequency band list
        private List<Int32> RFIDProtocolList = new List<Int32>();          // RFID protocol list


        #endregion
        private void button1_Click(object sender, EventArgs e)
        {

        }

        public String GetReadTagParam(String varParam)
        {
            String rt = "";

            #region Get antenna number & single reading/cyclic reading

            Int32 antNUM = 0;
            Int32 singleOrWhile = -1;
            int count = 0;
            foreach (var item in gb_ReadControl.Controls)
            {
                CheckBox control = item as CheckBox;
                if (control != null && control.Checked)
                {
                    if (Convert.ToInt32(control.Name.Substring(3)) <= 8)
                    {
                        antNUM += Int32.Parse(control.Tag.ToString());
                        if (count == 0)
                        {
                            antNo = (eAntennaNo)Int32.Parse(control.Tag.ToString());
                        }
                        else
                        {
                            antNo = antNo | (eAntennaNo)Int32.Parse(control.Tag.ToString());
                        }
                        count++;
                    }
                }
            }
            foreach (var item in gb_ReadControl.Controls)
            {
                CheckBox control = item as CheckBox;
                if (control != null && control.Checked)
                {
                    if (Convert.ToInt32(control.Name.Substring(3)) > 8)
                    {
                        if (count > 0)
                        {
                            antNo = antNo | RFIDReader._Tag6C.GeteAntennaNo(control.Name.Substring(3));
                        }
                        else
                        {
                            antNo = RFIDReader._Tag6C.GeteAntennaNo(control.Name.Substring(3));
                        }
                        count++;
                    }
                }
            }
            foreach (var item in gb_ReadType.Controls)
            {
                RadioButton control = item as RadioButton;
                if (control != null && control.Checked)
                {
                    singleOrWhile = Byte.Parse(control.Tag.ToString());
                    this.readType = (eReadType)singleOrWhile;
                }
            }
            rt += (Byte)antNUM + "|" + singleOrWhile + "|";

            #endregion


            #region Optional parameters

            string addAntParam = GetAddAntParam();

            if (!String.IsNullOrEmpty(varParam))
            {
                rt += varParam;
                if (antCount > 8)
                {
                    if (varParam.Contains(","))
                    {
                        if (rb_6c.Checked)
                        {
                            rt += "&10," + addAntParam;
                        }
                        else if (rb_6b.Checked)
                        {
                            rt += "&3," + addAntParam;
                        }
                        else if (rb_gb.Checked)
                        {
                            rt += "&6," + addAntParam;
                        }
                    }
                    else
                    {
                        if (rb_6c.Checked)
                        {
                            rt += "|10," + addAntParam;
                        }
                        else if (rb_6b.Checked)
                        {
                            rt += "|3," + addAntParam;
                        }
                        else if (rb_gb.Checked)
                        {
                            rt += "|6," + addAntParam;
                        }
                    }
                }
            }
            else
            {
                if (antCount > 8)
                {
                    if (rb_6c.Checked)
                    {
                        rt += "10," + addAntParam;
                    }
                    else if (rb_6b.Checked)
                    {
                        rt += "3," + addAntParam;
                    }
                    else if (rb_gb.Checked)
                    {
                        rt += "6," + addAntParam;
                    }
                }
            }

            #endregion

            rt = rt.TrimEnd('|');
            return rt;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        private void tsb_Read_Enable()
        {
            RFIDReader.DIC_CONNECT[ConnID].ProcessCount = 0;
            TJ_LastTagcount = 0;
            StartFlush();
            if (rb_While.Checked)
            {
                IsStartRead = true;
                CheckEnableButton();
            }
        }

        public void StartFlush()
        {
            if (IsFlush == true) return;
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object o)
            {
                IsFlush = true;
                long flushCount = 0;
                while (IsFlush)
                {
                    if (flushCount % 2 == 0) FlushState();
                    flushCount++;
                    System.Threading.Thread.Sleep(500);
                    // Application.DoEvents();
                }
            }));
        }
        private void CheckEnableButton()
        {
            //#region Restore control state

            //foreach (ToolStripItem item in menuStrip.Items)
            //{
            //    item.Enabled = true;
            //}
            //foreach (ToolStripItem item in tsm_Main.Items)
            //{
            //    item.Enabled = true;
            //}

            //#endregion

            //if (String.IsNullOrEmpty(ConnID))
            //{
            //    foreach (ToolStripItem item in menuStrip.Items)
            //    {
            //        item.Enabled = false;
            //    }
            //    tsmi_Connect.Enabled = true;
            //    tsmi_SearchDevice.Enabled = true;
            //    tsmi_Language.Enabled = true;
            //    foreach (ToolStripItem item in tsm_Main.Items)
            //    {
            //        item.Enabled = false;
            //    }
            //}
            //else
            //{
            //    if (IsStartRead)
            //    {

            //        foreach (ToolStripItem item in menuStrip.Items)
            //        {
            //            item.Enabled = false;
            //        }
            //        tsmi_Connect.Enabled = true;
            //        tsmi_Helper.Enabled = true;
            //        tsb_Read_Epc.Enabled = false;
            //        tsb_Read_EPCTID.Enabled = false;
            //        tsb_Read_Global.Enabled = false;
            //        tsb_Write_EPC.Enabled = false;
            //        tsb_Write_UserData.Enabled = false;
            //        tsb_WriteGlobal.Enabled = false;
            //    }
            //}

        }
        public void FlushState()
        {
            if (this.lb_ReceiveCount.InvokeRequired)
            {
                this.dtgridreader.BeginInvoke(new FlushState(FlushState), null);
                return;
            }
            Monitor.Enter(dtgridreader);
            try
            {
                long nowTagCount = RFIDReader.DIC_CONNECT[ConnID].ProcessCount;
                this.lb_ReceiveCount.Text = nowTagCount.ToString();
                //this.tssl_CacheSize.Text = RFIDReader.DIC_CONNECT[ConnID].receiveBufferManager.DataCount.ToString();
                //this.led_Tag_Count.Text = dic_Rows.Count.ToString();
                //Int32 totalMinutes = (Int32)((DateTime.Now - TJ_Run_Start).TotalMilliseconds / 1000);
                //led_Time.Text = totalMinutes.ToString();
                long l_Speed = Math.Abs(nowTagCount - TJ_LastTagcount);
                //led_Speed.Text = l_Speed.ToString();
                TJ_LastTagcount = nowTagCount;

                //float cpuLoad = pc_Processor.NextValue();
                //tssl_CPULoad.Text = cpuLoad.ToString("F2") + "%";           // CPU%
            }
            catch { }
            Monitor.Exit(dtgridreader);
        }
        public void WriteDebugMsg(string msg)
        {
            if (!IsWriteDebug) return;
            if (tb_DebugMsg.InvokeRequired)
            {
                tb_DebugMsg.BeginInvoke(new WriteDebug(WriteDebugMsg), msg);
                return;
            }
            tb_DebugMsg.AppendText(msg + Environment.NewLine);
            nowDebugMessageCount++;
        }
        /// <summary>
        /// 输出日志消息
        /// </summary>
        /// <param name="msg"></param>
        public void WriteLog(string msg)
        {
        }
        /// <summary>
        /// TCP客户端模式的读写器主动连接
        /// </summary>
        /// <param name="connID"></param>
        public void PortConnecting(String connID)
        {
            if (IsMultiConnect)
            {
                WriteDebugMsg("New Reader Connected：" + connID);
            }
            else
            {
                TCPPortConnectting(connID);
            }
        }
        private void TCPPortConnectting(string newConnID)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new TCPPortConn(TCPPortConnectting), newConnID);
                return;
            }
            if (!String.IsNullOrEmpty(ConnID))
            {

                CloseNowConnect();

                //不再进行重连，这样重连成功率不高
                RFIDReader.CreateTcpConn(newConnID, this);        //重新连接
                this.ConnID = newConnID;

                Init();

            }
            else
            {
                CloseNowConnect();
                this.ConnID = newConnID;
                Init();
            }
        }
        private void InitReaderProerty()
        {
            string strReaderProperty = Program.RFID_OPTION.GetReaderProperty(ConnID);
            string[] str_array = strReaderProperty.Split('|');
            if (str_array.Length == 5)
            {
                try
                {
                    minDB = Int32.Parse(str_array[0]);
                    maxDB = Int32.Parse(str_array[1]);
                    antCount = Int32.Parse(str_array[2]);
                    string[] str_bandList = str_array[3].Split(',');
                    string[] str_RFIDProtocolList = str_array[4].Split(',');
                    for (int i = 0; i < str_bandList.Length; i++)
                    {
                        bandList.Add(Int32.Parse(str_bandList[i]));
                    }
                    for (int i = 0; i < str_RFIDProtocolList.Length; i++)
                    {
                        RFIDProtocolList.Add(Int32.Parse(str_RFIDProtocolList[i]));
                    }
                }
                catch { }
            }
        }
        private void Init()
        {
            InitReaderProerty();

            CheckEnableButton();

            #region 天线能力

            foreach (var item in gb_ReadControl.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null)
                {
                    cb.BackColor = Color.Transparent;
                    string AntNum = cb.Name.ToString().Substring(3);
                    int index = Int32.Parse(AntNum);
                    if (index > antCount)
                    {
                        cb.Enabled = false;
                        cb.Checked = false;
                    }
                    else
                    {
                        cb.Enabled = true;
                    }
                }
            }
            #endregion


            dtgridreader.AutoGenerateColumns = false;
            Type type = dtgridreader.GetType();
            System.Reflection.PropertyInfo pi = type.GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(dtgridreader, true, null);

        }
        public void CloseNowConnect()
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                try
                {
                    if (IsStartRead)         //正在读取标签的情况断开连接
                    {
                        RFIDReader._RFIDConfig.Stop(ConnID);
                        IsStartRead = false;
                    }
                    RFIDReaderAPI.RFIDReader.CloseConn(ConnID);
                    ConnID = "";
                }
                catch { }
            }
            CheckEnableButton();
        }
        public void OutPutTagsOver()
        {
            // lb_tagTotalCount.Text = dic_Rows.Count.ToString();
            //  this.led_Tag_Count.Text = dic_Rows.Count.ToString();
            IsFlush = false;
        }
        public void GPIControlMsg(GPI_Model gpi_model)
        {
            if (gpi_model.StartOrStop == 0)
            {
                GPI_Start(gpi_model.GpiIndex - 1, gpi_model.GpiState);  //Subtract one for compatibility, change GPIindex to start from 1
            }
            else
            {
                GPI_End(gpi_model.GpiIndex - 1, gpi_model.GpiState);
            }
        }
        public void GPI_Start(Int32 gpiIndex, Int32 gpiState)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object o)
            {
                if (TJ_List_GPI_Button[gpiIndex].Tag.Equals("0")) return;
                lock (TJ_List_GPI_Button[gpiIndex])
                {
                    TJ_List_GPI_Button[gpiIndex].Tag = "0";
                }
                while (TJ_List_GPI_Button[gpiIndex].Tag.Equals("0"))
                {
                    if (gpiState == 0)
                    {
                        TJ_List_GPI_Button[gpiIndex].BackColor = Color.Red;
                    }
                    else
                    {
                        TJ_List_GPI_Button[gpiIndex].BackColor = Color.DimGray;
                    }
                    lock (TJ_List_GPI_Button[gpiIndex])
                    {
                        if (Monitor.Wait(TJ_List_GPI_Button[gpiIndex], 500))
                        {
                            break;
                        }
                    }
                    if (TJ_List_GPI_Button[gpiIndex].Tag.Equals("0"))
                    {
                        TJ_List_GPI_Button[gpiIndex].BackColor = Color.White;
                    }
                    else
                    {
                        break;
                    }
                    lock (TJ_List_GPI_Button[gpiIndex])
                    {
                        if (Monitor.Wait(TJ_List_GPI_Button[gpiIndex], 500))
                        {
                            break;
                        }
                    }
                }
            }), new object());
        }
        public void GPI_End(Int32 gpiIndex, Int32 gpiState)
        {
            lock (TJ_List_GPI_Button[gpiIndex])
            {
                Monitor.PulseAll(TJ_List_GPI_Button[gpiIndex]);
            }
            lock (TJ_List_GPI_Button[gpiIndex])
            {
                TJ_List_GPI_Button[gpiIndex].Tag = "1";
            }
            if (gpiState == 0)
            {
                TJ_List_GPI_Button[gpiIndex].BackColor = Color.Red;
            }
            else
            {
                TJ_List_GPI_Button[gpiIndex].BackColor = Color.DimGray;
            }
        }
        /// <summary>
        /// TCP对方主动关闭连接
        /// </summary>
        public void PortClosing(String connID)
        {
            if (this.ConnID.Equals(connID))
            {
                CloseNowConnect();
                Init();
            }
            WriteDebugMsg(connID + "Disconnect...");
        }
        /// <summary>
        ///  标签信息输出
        /// </summary>
        /// <param name="tag_Model"></param>
        public void OutPutTags(Tag_Model tag_Model)
        {
            if (!IsShowTag) return;
            if (tag_Model == null || tag_Model.Result != 0x00) return;
            bool isNew = false;
            DataGridViewRow dgvr = null;
            lock (dic_Rows)
            {
                try
                {
                    if (!dic_Rows.ContainsKey(tag_Model.EPC + "|" + tag_Model.TID))
                    {
                        // string x = JsonSerializer.Serialize(tag_Model);
                        dgvr = new DataGridViewRow();
                        dgvr.CreateCells(dtgridreader, new object[] { tag_Model.ReaderName, tag_Model.TagType,
                            tag_Model.EPC, tag_Model.TID, tag_Model.UserData, tag_Model.TagetData,
                            tag_Model.TotalCount, tag_Model.ANT1_COUNT, tag_Model.ANT2_COUNT,
                            tag_Model.ANT3_COUNT, tag_Model.ANT4_COUNT, tag_Model.ANT5_COUNT,
                            tag_Model.ANT6_COUNT, tag_Model.ANT7_COUNT, tag_Model.ANT8_COUNT,
                            tag_Model.ANT9_COUNT, tag_Model.ANT10_COUNT, tag_Model.ANT11_COUNT,
                            tag_Model.ANT12_COUNT, tag_Model.ANT13_COUNT, tag_Model.ANT14_COUNT,
                            tag_Model.ANT15_COUNT, tag_Model.ANT16_COUNT, tag_Model.ANT17_COUNT,
                            tag_Model.ANT18_COUNT, tag_Model.ANT19_COUNT, tag_Model.ANT20_COUNT,
                            tag_Model.ANT21_COUNT, tag_Model.ANT22_COUNT, tag_Model.ANT23_COUNT,
                            tag_Model.ANT24_COUNT,
                            tag_Model.RSSI, tag_Model.Frequency, tag_Model.Phase, tag_Model.ReadTime,
                            tag_Model.G2V2Challenge,tag_Model.G2V2Data,
                            tag_Model.EM_Temperature, tag_Model.RFMicron_Temperature});
                        dic_Rows.Add(tag_Model.EPC + "|" + tag_Model.TID, dgvr);
                        isNew = true;
                    }
                    else
                    {
                        dgvr = dic_Rows[tag_Model.EPC + "|" + tag_Model.TID];
                    }
                }
                catch { }
            }
            AddSingleTag(tag_Model, dgvr, isNew);
        }
        public void AddSingleTag(Tag_Model tag_6C, DataGridViewRow dgvr, Boolean isNew)
        {
            if (this.dtgridreader.InvokeRequired)
            {
                this.dtgridreader.BeginInvoke(new AddTag(AddSingleTag), tag_6C, dgvr, isNew);
                return;
            }
            try
            {
                if (!isNew)
                {

                    tag_ModelsPost.FirstOrDefault(t => t.EpcData == tag_6C.EpcData).TotalCount++;
                    Int64 newStr = (Int64)dgvr.Cells["clm_TotalCount"].Value + 1;
                    dgvr.Cells["clm_TotalCount"].Value = newStr;
                    if (tag_6C.ANT_NUM <= 24)
                    {
                        dgvr.Cells["clm_ANT" + tag_6C.ANT_NUM].Value = (Int64)dgvr.Cells["clm_ANT" + tag_6C.ANT_NUM].Value + 1;
                    }
                    dgvr.Cells["clm_UserData"].Value = tag_6C.UserData;
                    dgvr.Cells["clm_ReserveData"].Value = tag_6C.TagetData;
                    dgvr.Cells["clm_RSSI"].Value = tag_6C.RSSI;
                    dgvr.Cells["clm_ReadTime"].Value = tag_6C.ReadTime;
                    dgvr.Cells["clm_G2V2Data"].Value = tag_6C.G2V2Data;
                    dgvr.Cells["clm_G2V2Challenge"].Value = tag_6C.G2V2Challenge;
                    dgvr.Cells["clm_EpcData"].Value = tag_6C.EpcData;

                    dgvr.Cells["clm_EMTemp"].Value = tag_6C.EM_Temperature;
                    dgvr.Cells["clm_RFTemp"].Value = tag_6C.RFMicron_Temperature;
                }
                else
                {
                    tag_ModelsPost.Add(tag_6C);
                    dtgridreader.Rows.Add(dgvr);
                }
                // this.led_Tag_ReadCount.Text = RFIDReader.DIC_CONNECT[ConnID].ProcessCount.ToString();
            }
            catch { }
        }
        public String GetAddAntParam()
        {
            int addAntNum = 0;
            foreach (var item in gb_ReadControl.Controls)
            {
                CheckBox control = item as CheckBox;
                if (control != null && control.Checked)
                {
                    if (Convert.ToInt32(control.Name.Substring(3)) > 8)
                    {
                        addAntNum += Int32.Parse(control.Tag.ToString());
                    }
                }
            }

            if (addAntNum != 0)
            {
                return Convert.ToString(addAntNum, 16).PadLeft(4, '0');
            }
            else
            {
                return "0000";
            }

        }
        private void tsb_ClearList_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckNowConnect())
                {

                    RFIDReaderAPI.RFIDReader.DIC_CONNECT[ConnID].ClearTagData();
                }

            }
            catch { }
        }
        private Boolean CheckNowConnect()
        {
            if (String.IsNullOrEmpty(ConnID))
            {
                MessageBox.Show("error");
                return false;
            }
            else
            {
                return true;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIpAddress.Text))
            {
                try
                {
                    ConnID = txtIpAddress.Text.Trim();
                    isConnect = RFIDReader.CreateTcpConn(ConnID.Trim(), this);
                    MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/AddConnect", "TcpConnect", ConnID.Trim());
                    btnClose.Enabled = true;
                    btnRead.Enabled = true;
                    BtnConnect.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Server Start Error：" + ex.Message);
                }
            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnConnect_Click_1(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtIpAddress.Text))
            {
                try
                {
                    ConnID = txtIpAddress.Text.Trim();
                    isConnect = RFIDReader.CreateTcpConn(ConnID.Trim(), this);
                    MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/AddConnect", "TcpConnect", ConnID.Trim());
                    btnClose.Enabled = true;
                    btnRead.Enabled = true;
                    BtnConnect.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Server Start Error：" + ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            IsStartRead = false;
            IsFlush = false;
            RFIDReader._Tag6C.Stop(ConnID);
            CheckEnableButton();
            ConnID = null;
            btnClose.Enabled = false;
            btnRead.Enabled = false;
            BtnConnect.Enabled = true;
            tag_ModelsPost = null;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            Program.RFID_OPTION.StopReader(ConnID);
            tsb_ClearList_Click(null, null);

            // txtreading.Text = null;
            int st = -1;
            GetReadTagParam("");
            if (rb_6c.Checked)
            {
                st = RFIDReader._Tag6C.GetEPC(ConnID.Trim(), eAntennaNo._1, eReadType.Inventory);
            }
            else if (rb_6b.Checked)
            {
                st = RFIDReader._Tag6B.Get6B(ConnID, antNo, readType, e6BReaderContent.TID);
            }
            else if (rb_gb.Checked)
            {
                st = RFIDReader._TagGB.GetEPC(ConnID, antNo, readType);
            }
            if (st != 0) { MessageBox.Show("error"); return; }
            tsb_Read_Enable();
        }

        private string Postdate(string url, object dto)
        {
            HttpClientService httpClientService = new HttpClientService();
            var restult = httpClientService.CallServicePost(UserData.Url + url, dto, UserData.UserToken);
            return restult;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tag_ModelsPost = null;
           
            for (int i = 0; i <= dtgridreader.Rows.Count - 1; i++)
            {
                //dgw.Rows[i].Cells[0].Value
                tag_ModelsPost.Add(new Tag_Model { TotalCount = (long)dtgridreader.Rows[i].Cells[6].Value,TID= (string)dtgridreader.Rows[i].Cells[2].Value });
            }
            DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (tag_ModelsPost.Count == 0)
                {
                    MessageBox.Show("Thier Is No data To send");
                    return;
                }
                IsStartRead = false;
                IsFlush = false;
                RFIDReader._Tag6C.Stop(ConnID);
                CheckEnableButton();
                ConnID = null;
                btnClose.Enabled = false;
                btnRead.Enabled = false;
                BtnConnect.Enabled = true;
                CreateTransactionForm createTransactionForm = new CreateTransactionForm(tag_ModelsPost);
                createTransactionForm.ShowDialog();
            }
            
           
        }


    }
}