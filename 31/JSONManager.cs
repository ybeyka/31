using System;
using System.Text.Json;

namespace MyDataManager
{
    public class JSONManager
    {
        private PersonData _person;

        public JSONManager(PersonData person)
        {
            _person = person ?? throw new ArgumentNullException(nameof(person));
        }

        public void Save(string path)
        {
            var json = JsonSerializer.Serialize(_person);
            File.WriteAllText(path, json);
        }

        public void Load(string path)
        {
            var json = File.ReadAllText(path);
            _person = JsonSerializer.Deserialize<PersonData>(json);
            Console.WriteLine($"From JSON - Name: {_person.Name}, Age: {_person.Age}, Email: {_person.Email}");
        }
    }
}
