// Define lender class
using System;

namespace ConsoleApp1
{
    public class Lender
    {
        //Fields
        private string _name;
        private string _address;
        private string _city;
        private string _state;
        private string _zip;
        private string _phone;
        private string _email;

        //Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        
        //Constructors
        public Lender()
        {
            _name = "";
            _address = "";
            _city = "";
            _state = "";
            _zip = "";
            _phone = "";
            _email = "";
        }

        public Lender(string name, string address, string city, string state, string zip, string phone, string email)
        {
            _name = name;
            _address = address;
            _city = city;
            _state = state;
            _zip = zip;
            _phone = phone;
            _email = email;
        }

        //Methods
        public override string ToString()
        {
            return _name + "\n" + _address + "\n" + _city + ", " + _state + " " + _zip + "\n" + _phone + "\n" + _email;
        }

    }
}
