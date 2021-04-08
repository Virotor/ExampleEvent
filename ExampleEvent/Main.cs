using ExampleEvent;
using System;
using System.Collections;

StudentCollection studentCollection1 = new() {CollectionName = "StudentColection1"};
StudentCollection studentCollection2 = new() { CollectionName = "StudentColection2" };

Journal journal1 = new();
Journal journal2 = new();

studentCollection1.StudentReferenceChanged += journal1.ChangedReference;
studentCollection1.StudentsCountChanged += journal1.ChangedCountOfCollection;
studentCollection1.StudentReferenceChanged += journal2.ChangedReference;
studentCollection2.StudentReferenceChanged += journal2.ChangedReference;

studentCollection1.AddDefaults();
studentCollection2.AddDefaults();

studentCollection1.AddStudents(new Student("Pay", 2311, new ArrayList() { (true,"PE"), (false, "Economics")}, new ArrayList() { (10, "SPO"), (5,"Physics")}));

studentCollection1.Remove(3);
studentCollection1.Remove(2);
studentCollection1[0] = new Student("Free", 1111, new ArrayList(){(true,"Electronic Systems"), (false, "Phylosofia")},new ArrayList() {(10,"Math") ,(7, "TCO")} );
studentCollection1[1] = new Student("PayFree", 2222, new ArrayList() { (true, "Electronic Systems"), (false, "Phylosofia") }, new ArrayList() { (4, "Math"), (6, "TCO") });
studentCollection2[1] = new Student("Pay", 3333, new ArrayList() { (false, "Electronic Systems"), (true, "Phylosofia") }, new ArrayList() { (6, "Math"), (6, "TCO") });
studentCollection2[3] = new Student("FreePay", 4444, new ArrayList() { (true, "Electronic Systems"), (true, "Phylosofia") }, new ArrayList() { (8, "Math"), (9, "TCO") });

Console.WriteLine(journal1.ToString());
Console.WriteLine(journal2.ToString());

Console.ReadKey();