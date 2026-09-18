using GymShark.ForObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymShark
{
    enum TypeofObject
    {
        Price,
        Sale,
        Name,
        Chapter,
        For,
    }

    class Product
    {
        public int Count { get; private set; }
        public readonly TypeProduct TypeProduct;

        public Product(string name, Price price, Chapter chapter, For _for)
        {
            TypeProduct = new TypeProduct(name, price, chapter,_for);
        }
        public void AddProduct(int Count)
        {
            Count++;
        }

        public void RemoveProduct()
        {
            Count--;
        }
    }
    class TypeProduct
    {
        public Price Price { get; private set; }
        public string Name { get; private set; }

        public readonly Guid Id;
        public Chapter Chapter { get; private set; }
        public For For { get; private set; }

        public TypeProduct(string name,Price price,Chapter chapter,For _for)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Chapter = chapter;
            For = _for;
        }

        public void ChangeParametr(TypeofObject type, dynamic obj)
        {
            try
            {
                switch (type)
                {
                    case TypeofObject.Price: if (obj is Price) Price = obj; break;
                    case TypeofObject.Name: if (obj is string) Name = obj; break;
                    case TypeofObject.Chapter: Chapter = obj; break;
                    case TypeofObject.For: For = obj; break;
                }
            }
            catch
            {

            }
        }
    }
}
