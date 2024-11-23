using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Soap;

public class Academy_Group
{
    private ArrayList students;
    private int count;

    public Academy_Group()
    {
        students = new ArrayList();
        count = 0;
    }

    public void add(Student student)
    {
        students.Add(student);
        count++;
    }

    public void remove(string surname)
    {
        foreach (Student student in students)
        {
            if (student.Surname == surname)
            {
                students.Remove(student);
                count--;
                Console.WriteLine("You removed student");
                return;
            }
        }
        Console.WriteLine("Cannot find student");
    }

    public void edit(string surname, Student new_st)
    {
        for (int i = 0; i < students.Count; i++)
        {
            Student student = (Student)students[i];
            if (student.Surname == surname)
            {
                students[i] = new_st;
                Console.WriteLine("You updated student info");
                return;
            }
        }
        Console.WriteLine("Cannot find student");
    }

    public void print()
    {
        Console.WriteLine("Academy Group:");
        foreach (Student student in students)
        {
            student.print();
        }
    }

    public void save(string filePath)
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(students.Count);
                foreach (Student student in students)
                {
                    writer.Write(student.Name);
                    writer.Write(student.Surname);
                    writer.Write(student.Age);
                    writer.Write(student.Phone);
                    writer.Write(student.Average);
                    writer.Write(student.Number_Of_Group);
                }
            }
            Console.WriteLine("File saved");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with saving: {ex.Message}");
        }
    }

    public void load(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                students.Clear();
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int studentCount = reader.ReadInt32();
                    for (int i = 0; i < studentCount; i++)
                    {
                        string name = reader.ReadString();
                        string surname = reader.ReadString();
                        int age = reader.ReadInt32();
                        string phone = reader.ReadString();
                        double average = reader.ReadDouble();
                        int group_num = reader.ReadInt32();
                        Student student = new Student(name, surname, age, phone, average, group_num);
                        students.Add(student);
                    }
                }
                Console.WriteLine("File loaded");
                count = students.Count;
            }
            else
            {
                Console.WriteLine("Cannot load file");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with loading: {ex.Message}");
        }
    }

    public void search(string surname)
    {
        foreach (Student student in students)
        {
            if (student.Surname == surname)
            {
                student.print();
                return;
            }
        }
        Console.WriteLine("Cannot find student");
    }

    public void save_xml(string filePath)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayList), new Type[] { typeof(Student) });
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, students);
            }
            Console.WriteLine("Data saved");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void load_xml(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayList), new Type[] { typeof(Student) });
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    students = (ArrayList)serializer.Deserialize(fs);
                }
                count = students.Count;
                Console.WriteLine("Data loaded");
            }
            else
            {
                Console.WriteLine("XML not found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void save_json(string filePath)
    {
        try
        {
            string json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine("Data saved");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void load_json(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                students = JsonConvert.DeserializeObject<ArrayList>(json);
                count = students.Count;
                Console.WriteLine("Data loaded");
            }
            else
            {
                Console.WriteLine("JSON not found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void save_soap(string filePath)
    {
        try
        {
            SoapFormatter formatter = new SoapFormatter();
            Student[] student_array = (Student[])students.ToArray(typeof(Student));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fs, student_array);
            }
            Console.WriteLine("Data saved");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    public void load_soap(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                SoapFormatter formatter = new SoapFormatter();
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    Student[] student_array = (Student[])formatter.Deserialize(fs);
                    students = new ArrayList(student_array);
                }
                count = students.Count;
                Console.WriteLine("Data loaded");
            }
            else
            {
                Console.WriteLine("SOAP not found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
