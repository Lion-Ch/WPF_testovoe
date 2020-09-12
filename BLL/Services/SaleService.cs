using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Responses;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class SaleService:BaseService<Sale,SaleDTO> 
    {
        public SaleService() : base(new SaleRepository())
        {
        }

        public override Response CreateRange(IEnumerable<SaleDTO> list)
        {
            Response res = PreparationRange(list);
            if (res.Status != TypeRespone.OK)
                return res;
            return base.CreateRange(list);
        }

        public override Response IsValidObject(SaleDTO item)
        {
            
            return base.IsValidObject(item);
        }

        public override Response PreparationObject(SaleDTO item)
        {
            Sale s = Repository.Get(mapper.Map<Sale>(item));
            if (s != null)
                return new Response("Данная запись уже есть в базе!", TypeRespone.WARNING);
            else
            {
                using (ProductRepository prodRep = new ProductRepository())
                {
                    Product p = prodRep.Get(item.ProductId);
                    int amountProduct = p.Amount;
                    if (amountProduct < item.Amount)
                        return new Response($"Товара {p.Name} всего {amountProduct} шт. на складе!", TypeRespone.WARNING);
                    else
                        p.Amount -= item.Amount - item.Amount;

                    prodRep.Save();
                }
                return new Response("", TypeRespone.OK);
            }
                
        }
    }
}
