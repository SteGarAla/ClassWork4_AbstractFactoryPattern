using ClassWork4_AbstractFactoryPattern;
using System;

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
           PhoneTypeChecker ok = new PhoneTypeChecker(Manufacturers.SAMSUNG);
            ok.CheckProducts();


        }
    }


    //test



    class PhoneTypeChecker
    {
        //attributes
        IPhoneFactory factory;
        Manufacturers manu;

        //Operations
       public PhoneTypeChecker(Manufacturers m)
        {
            this.manu = m;
        }

        public void CheckProducts()
        {
            switch (manu)
            {
                case Manufacturers.SAMSUNG:
                    new SamsungFactory();
                    break;

                case Manufacturers.HTC:
                    new HTCFactory();
                    break;

                case Manufacturers.NOKIA:
                    new NokiaFactory();
                    break;

            }
        }

    }


    //ISMART INTERFACE FOR LUMIA, GALAXYS2 AND TITAN  CLASSES
    interface ISmart
    {
        string getSmart();
    }


    //IDUMB INTERFACE FOR ASHA, GENIE, PRIMO  CLASSES
    interface IDumb
    {
        string getDumb();
    }


    interface IPhoneFactory : IDumb,ISmart
    {
        new ISmart getSmart();
        new IDumb getDumb();
    }


    class SamsungFactory : IPhoneFactory
    {
        public IDumb getDumb()
        {
            throw new NotImplementedException();
        }

        public ISmart getSmart()
        {
            throw new NotImplementedException();
        }

        string IDumb.getDumb()
        {
            throw new NotImplementedException();
        }

        string ISmart.getSmart()
        {
            throw new NotImplementedException();
        }
    }



























    class Lumia : ISmart
    {
        public string getSmart()
        {
            return "Lumia";
        }
    }

    class GalaxyS2 : ISmart
    {
        public string getSmart()
        {
            return "GalaxyS2";
        }
    }

    class Titan : ISmart
    {
        public string getSmart()
        {
            return "Titan";
        }
    }


    class Asha : IDumb
    {
        public string getDumb()
        {
            return "Asha";
        }
    }

    class Genie : IDumb
    {
        public string getDumb()
        {
            return "Genie";
        }
    }

    class Primo : IDumb
    {
        public string getDumb()
        {
            return "Primo";
        }
    }




}