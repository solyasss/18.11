using System;

class Main_Class
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Clear();

        Academy_Group group = new Academy_Group();
        string binaryFilePath = "students.dat";
        string xmlFilePath = "students.xml";
        string jsonFilePath = "students.json";
        string soapFilePath = "students.soap";

        while (true)
        {
            Console.WriteLine("\n-----Academy Menu-----");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Remove Student");
            Console.WriteLine("3. Edit Student");
            Console.WriteLine("4. Print Group");
            Console.WriteLine("5. Search Student");
            Console.WriteLine("6. Save to Binary File");
            Console.WriteLine("7. Load from Binary File");
            Console.WriteLine("8. Save to XML File");
            Console.WriteLine("9. Load from XML File");
            Console.WriteLine("10. Save to JSON File");
            Console.WriteLine("11. Load from JSON File");
            Console.WriteLine("12. Save to SOAP File");
            Console.WriteLine("13. Load from SOAP File");
            Console.WriteLine("14. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice, please enter a number.");
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("Enter age: ");
                        if (!int.TryParse(Console.ReadLine(), out int age))
                        {
                            Console.WriteLine("Invalid age");
                            break;
                        }
                        Console.Write("Enter phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Enter average: ");
                        if (!double.TryParse(Console.ReadLine(), out double average))
                        {
                            Console.WriteLine("Invalid average");
                            break;
                        }
                        Console.Write("Enter group number: ");
                        if (!int.TryParse(Console.ReadLine(), out int group_num))
                        {
                            Console.WriteLine("Invalid group number");
                            break;
                        }
                        Student new_student = new Student(name, surname, age, phone, average, group_num);
                        group.add(new_student);
                        break;

                    case 2:
                        Console.Write("Enter surname of student to remove: ");
                        string remove_surname = Console.ReadLine();
                        group.remove(remove_surname);
                        break;

                    case 3:
                        Console.Write("Enter surname of student to edit: ");
                        string edit_surname = Console.ReadLine();
                        Console.Write("Enter new name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter new surname: ");
                        surname = Console.ReadLine();
                        Console.Write("Enter new age: ");
                        if (!int.TryParse(Console.ReadLine(), out age))
                        {
                            Console.WriteLine("Invalid age");
                            break;
                        }
                        Console.Write("Enter new phone: ");
                        phone = Console.ReadLine();
                        Console.Write("Enter new average: ");
                        if (!double.TryParse(Console.ReadLine(), out average))
                        {
                            Console.WriteLine("Invalid average");
                            break;
                        }
                        Console.Write("Enter new group number: ");
                        if (!int.TryParse(Console.ReadLine(), out group_num))
                        {
                            Console.WriteLine("Invalid group number");
                            break;
                        }
                        Student ready_student = new Student(name, surname, age, phone, average, group_num);
                        group.edit(edit_surname, ready_student);
                        break;

                    case 4:
                        group.print();
                        break;

                    case 5:
                        Console.Write("Enter surname of student to search: ");
                        string search_surname = Console.ReadLine();
                        group.search(search_surname);
                        break;

                    case 6:
                        group.save(binaryFilePath);
                        break;

                    case 7:
                        group.load(binaryFilePath);
                        break;

                    case 8:
                        group.save_xml(xmlFilePath);
                        break;

                    case 9:
                        group.load_xml(xmlFilePath);
                        break;

                    case 10:
                        group.save_json(jsonFilePath);
                        break;

                    case 11:
                        group.load_json(jsonFilePath);
                        break;

                    case 12:
                        group.save_soap(soapFilePath);
                        break;

                    case 13:
                        group.load_soap(soapFilePath);
                        break;

                    case 14:
                        return;

                    default:
                        Console.WriteLine("Incorrect choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
