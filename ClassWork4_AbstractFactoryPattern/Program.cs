/*
 * Name: Steven Garcia-Alamilla
 * Date: 02/03/23
 * 
 * Project: CW4
 * 
 */


using System;

namespace ClassWork4_AbstractFactoryPattern
{

        //enum for all the manufactures
        //not sure if im supposed to put this in a class
        enum Manufacturers
        {
            SAMSUNG,
            HTC,
            NOKIA
        }
    

    class PhoneTypeChecker
    {
        //attributes
        IPhoneFactory factory;
        Manufacturers manu;

        //parameterized constructor
        public PhoneTypeChecker(Manufacturers m)
        {
            manu = m;
        }

        public void CheckProducts()
        { 
            //based on the enum passed, it will set factory to that instance 
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

            //im not sure how to make this shorters
            Console.WriteLine(Enum.GetName(typeof(Manufacturers), manu) + " SMART: " + factory.GetSmart().getName());
            Console.WriteLine(Enum.GetName(typeof(Manufacturers), manu) + " DUMB: " + factory.GetDumb().getName());
        }
    }

    //interface ISmart has one method getName()
    interface ISmart
    {
        string getName();
    }

    //interface IDumb has one method getName()
    interface IDumb
    {
        string getName();
    }


    //my mistake was making this implement ISmart and IDumb (was very painful)
    interface IPhoneFactory
    {
        ISmart GetSmart();
        IDumb GetDumb();
    }


    /*
     * SamsungFactory implements the IPhoneFactory and implments both of its operations
     * It will return an instance of either IDumb and ISmart depending on which method is called
     */
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


    /*
     * HTCFactory implements the IPhoneFactory and implments both of its operations
     * It will return an instance of either IDumb and ISmart depending on which method is called
     */
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


    /*
     * //NokiaFactory implements the IPhoneFactory and implments both of its operations
     * It will return an instance of either IDumb and ISmart depending on which method is called
     */
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

    //Lumia implements the ISmart interface and will return its name
    class Lumia : ISmart
    {
        public string getName()
        {
            return "Lumia";
        }
    }

    //GalaxyS2 implements the ISmart interface and will return its name
    class GalaxyS2 : ISmart
    {
        public string getName()
        {
            return "GalaxyS2";
        }
    }

    //Titan implements the ISmart interface and will return its name
    class Titan : ISmart
    {
        public string getName()
        {
            return "Titan";
        }
    }

    //Asha implements the IDumb interface and will return its name
    class Asha : IDumb
    {
        public string getName()
        {
            return "Asha"; ;
        }
    }

    //Genie implements the IDumb interface and will return its name
    class Genie : IDumb
    {
        public string getName()
        {
            return "Genie"; 
        }
    }

    //primo implements the IDumb interface and will return its name
    class Primo : IDumb
    {
        public string getName()
        {
            return "Primo";
        }
    }


    /*
     * The entry point of the program, it will pass in a enum and based on the enums value it will
     * return the smart and dumb versions of that phone
     */
    class EntryPoint
    {

        static void Main()
        {
            //passing in the Samsung enum
            PhoneTypeChecker obj = new PhoneTypeChecker(Manufacturers.SAMSUNG);
            //returning results for the manufactures phone
            obj.CheckProducts();

            //passing in the HTC enum
            PhoneTypeChecker obj2 = new PhoneTypeChecker(Manufacturers.HTC);
            //returning results for the manufactures phone
            obj2.CheckProducts();

            //passing in the NOKIA enum
            PhoneTypeChecker obj3 = new PhoneTypeChecker(Manufacturers.NOKIA);
            //returning results for the manufactures phone
            obj3.CheckProducts();
        }
    }

}