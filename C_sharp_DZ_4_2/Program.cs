using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Разработать архитектуру классов иерархии товаров при разработке системы управления потоками товаров для дистрибьюторской компании.
Прописать члены классов. Создать диаграммы взаимоотношений классов. Должны быть предусмотрены разные типы товаров, в том числе:
• бытовая химия;
• продукты питания.
Предусмотреть классы управления потоком товаров (пришло, реализовано, списано, передано).*/
namespace C_sharp_DZ_4_2
{
    public class Product        //Товары
    {
        int _article;
        string _name;
        double _price;
        int _balance;
        public Product(int _article, string _name)
        {
            this._article = _article;
            this._name = _name;
        }
        public Product(int _article, string _name, double _price, int _balance)
        {
            this._article = _article;
            this._name = _name;
            this._price = _price;
            this._balance = _balance;
        }
        public virtual void ProductReport()
        {
            Console.WriteLine($"Артикул: {_article:D4}");
            Console.WriteLine($"Наименование: {_name}");
            Console.WriteLine($"Цена: {_price:C2}");
            Console.WriteLine($"Остаток: {_balance}\n");
        }
    }
    class HouseholdChemicals : Product      //Бытовая химия
    {
        string _categoryHoushold;
        public HouseholdChemicals(int _article, string _name, double _price,int _balance, string _categoryHoushold = "Бытовая химия")
            :base(_article, _name, _price, _balance)
        {
            this._categoryHoushold = _categoryHoushold;
        }
        public override void ProductReport()
        {
            Console.WriteLine($"Категория: {_categoryHoushold}");
            base.ProductReport();
        }
    }
    class Food : Product        //Продукты питания
    {
        string _categoryFood;
        public Food(int _article, string _name, double _price, int _balance, string _categoryFood = "Продукты питания")
            : base(_article, _name, _price, _balance)
        {
            this._categoryFood = _categoryFood;
        }
        public override void ProductReport()
        {
            Console.WriteLine($"Категория: {_categoryFood}");
            base.ProductReport();
        }
    }
    class ConstructionMaterials : Product       //Строительные материалы
    {
        string _categoryConstruction;
        public ConstructionMaterials(int _article, string _name, double _price, int _balance, string _categoryConstruction = "Строительные материалы")
            : base(_article, _name, _price, _balance)
        {
            this._categoryConstruction = _categoryConstruction;
        
        }
        public override void ProductReport()
        {
            Console.WriteLine($"Категория: {_categoryConstruction}");
            base.ProductReport();
        }
    }




    class ProductManagement : Product       //Управление потоком товаров
    {
        int _invoiceNumber;
        public ProductManagement(int _article, string _name, int _invoiceNumber)
            : base(_article, _name)
        {
            this._invoiceNumber = _invoiceNumber;
        }
        public virtual void Change()
        {
            
        }

    }
    class Сoming : ProductManagement      //Приход
    {
        int _coming;
        public Сoming(int _article, string _name, int _invoiceNumber, int _coming)
            : base(_article, _name, _invoiceNumber)
        {
            this._coming = _coming;
        }



    }
    class Selling : ProductManagement     //Реализовано
    {
        int _selling;
        public Selling(int _article, string _name, int _invoiceNumber, int _selling)
            : base(_article, _name, _invoiceNumber)
        {
            this._selling = _selling;
        }

    }



    class WriteOff : ProductManagement        //Списание
    {
        int _wrightOff;
        public WriteOff(int _article, string _name, int _invoiceNumber, int _wrightOff)
            : base(_article, _name, _invoiceNumber)
        {
            this._wrightOff = _wrightOff;
        }

    }
    class Transfer:ProductManagement      //Передано
    {
        int _transfer;
        public Transfer(int _article, string _name, int _invoiceNumber, int _transfer)
            : base(_article, _name,  _invoiceNumber)
        {
            this._transfer = _transfer;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Product[] HousholdTest = {
                new HouseholdChemicals(001,"Порошок", 38.66, 1457),
                new HouseholdChemicals(002,"Зубная паста", 73.26, 2357),
                new HouseholdChemicals(003,"Мыло", 18.28, 4330)
            };
            foreach (HouseholdChemicals item in HousholdTest) item.ProductReport();
            Console.WriteLine();
            Product[] FoodTest = {
                new Food(001,"Хлеб", 18.34, 5347),
                new Food(002,"Масло", 52.61, 3712),
                new Food(003,"Молоко", 25.28, 6743),
                new Food (004, "Яблоко", 35.92, 9847)
            };
            foreach (Food item in FoodTest) item.ProductReport();
            Console.WriteLine();
            Product[] ConstructionTest = {
                new ConstructionMaterials(001,"Кирпич", 21.34, 5347),
                new ConstructionMaterials(002,"Плитка", 123.75, 4712),
                new ConstructionMaterials(003,"Клей", 138.12, 7340),
                new ConstructionMaterials(004,"Утеплитель", 75.40, 9820),
                new ConstructionMaterials(005,"Стекло", 121.38, 2398)
            };
            foreach (ConstructionMaterials item in ConstructionTest) item.ProductReport();
            Console.WriteLine();





            Console.ReadKey();
        }
    }
}
