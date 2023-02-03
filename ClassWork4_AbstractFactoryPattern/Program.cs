using ClassWork4_AbstractFactoryPattern;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ClassWork4_AbstractFactoryPattern
{
    enum Manufacturers
    {
        SAMSUNG,
        HTC,
        NOKIA
    }









    class EntryPoint
    {
        static void Main()
        {


            PhoneTypeChecker obj = new PhoneTypeChecker(Manufacturers.SAMSUNG);
            obj.CheckProducts();


            PhoneTypeChecker obj2 = new PhoneTypeChecker(Manufacturers.HTC);
            obj2.CheckProducts();

            PhoneTypeChecker obj3 = new PhoneTypeChecker(Manufacturers.NOKIA);
            obj3.CheckProducts();
        }
    }





    class PhoneTypeChecker
    {
        //attributes
        IPhoneFactory factory;
        Manufacturers manu;

        //Operations

        public PhoneTypeChecker(Manufacturers m)
        {
            manu = m;
        }

        public void CheckProducts()
        {

            switch (manu)
            {
                case Manufacturers.SAMSUNG:

                    factory = new SamsungFactory();
                    break;
                case Manufacturers.HTC:
                    factory = new HTCFactory();
                    break;

                case Manufacturers.NOKIA:
                    factory = new NokiaFactory();
                    break;
            }

            Console.WriteLine(factory.GetSmart());
        }
    }


    interface ISmart
    {
        string getName();
    }

    interface IDumb
    {
        string getName();
    }


    interface IPhoneFactory
    {
        ISmart GetSmart();
        IDumb GetDumb();
    }




    //SAMSUNG FACTORY
    class SamsungFactory : IPhoneFactory
    {
        public IDumb GetDumb()
        {
            return new Genie();
        }

        public ISmart GetSmart()
        {
            return new GalaxyS2();
         }


    }



    //HTC FACTORY (looks good )
    class HTCFactory : IPhoneFactory
    {
        public IDumb GetDumb()
        {
            return new Primo();
        }

        public ISmart GetSmart()
        {
            return new Titan();
        }
    }





    //NOKIA FACTORY (looks good so far)
    class NokiaFactory : IPhoneFactory
    {
        public IDumb GetDumb()
        {
            return new Asha();
        }

        public ISmart GetSmart()
        {
            return new Lumia();
        }
    }



















    //Looking good so far


    class Lumia : ISmart
    {
        public string getName()
        {
            return "Lumia";
        }
    }

    class GalaxyS2 : ISmart
    {
        public string getName()
        {
            return "GalaxyS2";
        }
    }

    class Titan : ISmart
    {
        public string getName()
        {
            return "Titan";
        }
    }


    class Asha : IDumb
    {
        public string getName()
        {
            return "Asha"; ;
        }
    }

    class Genie : IDumb
    {
        public string getName()
        {
            return "Genie"; 
        }
    }

    class Primo : IDumb
    {
        public string getName()
        {
            return "Primo";
        }
    }

}