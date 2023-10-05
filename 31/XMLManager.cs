using System;
using System.Xml.Serialization;
using System.IO;

namespace MyDataManager
{
    public class XMLManager
    {
        private PersonData _person;

        public XMLManager(PersonData person)
        {
            _person = person ?? throw new ArgumentNullException(nameof(person));
        }

        public void Save(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PersonData));
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(stream, _person);
            }
        }

        public void Load(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PersonData));
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                _person = (PersonData)serializer.Deserialize(stream);
            }
            Console.WriteLine($"From XML - Name: {_person.Name}, Age: {_person.Age}, Email: {_person.Email}");
        }
    }
}
