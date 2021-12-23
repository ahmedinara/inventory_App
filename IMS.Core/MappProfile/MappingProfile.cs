using AutoMapper;
using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Models;
using System;
using System.Linq;

namespace IMS.Core.MappProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
                this.CreateMap<User, UserModel>()
             .ReverseMap();
            this.CreateMap<RfIdScannedProduct, ScannedProductsModel>()
            .ForMember(mod => mod.Items, opt => opt.MapFrom(ent => ent.ItemScanneds))
            .ReverseMap();

            this.CreateMap<ItemScanned, ItemScannedModel>()
             .ReverseMap();

            this.CreateMap<ProductMaster, ProductMasterModel>()
            .ReverseMap();

            this.CreateMap<TransferIn, TransferInModel>()
            .ReverseMap();
            this.CreateMap<TransferInModel, TransactionInDeskTopDto>()
           .ReverseMap();
            this.CreateMap<TransferIn, TransactionInDeskTopDto>()
           .ReverseMap();

            this.CreateMap<TransferInDetail, TransferInDetailsModel>()
            .ReverseMap();

            this.CreateMap<Stock, Stock>()
            .ReverseMap();

            this.CreateMap<TransferOut, TransferOutModel>()
            .ReverseMap();

            this.CreateMap<TransferOutDetail, TransferOutDetialModel>()
            .ReverseMap();

            this.CreateMap<Supplier, SupplierModel>()
            .ReverseMap();

            this.CreateMap<Custmer, CustmerModel>()
           .ReverseMap();

            this.CreateMap<ProductVarient, ProductVarientWithParentModel > ()
           .ForMember(mod => mod.TitleAr, opt => opt.MapFrom(ent => ent.Product.TitleAr))
           .ForMember(mod => mod.TitleEn, opt => opt.MapFrom(ent => ent.Product.TitleEn))
           .ForMember(mod => mod.StockQty, opt => opt.MapFrom(ent => ent.Stocks.ToList().Sum(s=>s.AvaliableStock)))
           .ReverseMap();

            this.CreateMap<ProductVarient, ProductVarientModel>()
            .ReverseMap();
        }
    }
}
