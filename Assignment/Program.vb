Imports System

Class Student
    Public Property StudentID As Integer
    Public Property FirstName As String
    Public Property LastName As String

    Public Sub New(id As Integer, first As String, last As String)
        StudentID = id
        FirstName = first
        LastName = last
    End Sub
End Class

Module Program
    Dim students(50) As Student
    Dim studentCount As Integer = 0

    Sub Main()
        Dim choice As Integer

        Do
            Console.WriteLine("Student Management System")
            Console.WriteLine("1. Add Student")
            Console.WriteLine("2. Delete Student")
            Console.WriteLine("3. Display All Students")
            Console.WriteLine("4. Exit")
            Console.Write("Enter your choice: ")
            choice = Console.ReadLine()

            Select Case choice
                Case 1
                    AddStudent()
                Case 2
                    DeleteStudent()
                Case 3
                    DisplayStudent()
                Case 4
                    Exit Do
                Case Else
                    Console.WriteLine("Invalid choice. Please try again.")
            End Select
        Loop While True
    End Sub

    Sub AddStudent()
        Console.Write("Enter Student ID: ")
        Dim id As Integer = Console.ReadLine()
        Console.Write("Enter First Name: ")
        Dim first As String = Console.ReadLine()
        Console.Write("Enter Last Name: ")
        Dim last As String = Console.ReadLine()

        students(studentCount) = New Student(id, first, last)
        studentCount += 1
        Console.WriteLine("Student added successfully!")
    End Sub

    Sub DeleteStudent()
        Console.Write("Enter Student ID or Name to delete: ")
        Dim searchKey As String = Console.ReadLine()

        Dim foundIndex As Integer = -1
        For i As Integer = 0 To studentCount - 1
            If students(i).StudentID.ToString() = searchKey OrElse
           students(i).FirstName.ToLower() = searchKey.ToLower() OrElse
           students(i).LastName.ToLower() = searchKey.ToLower() Then
                foundIndex = i
                Exit For
            End If
        Next

        If foundIndex <> -1 Then

            For j As Integer = foundIndex To studentCount - 2
                students(j) = students(j + 1)
            Next
            studentCount -= 1
            Console.WriteLine("Student deleted successfully!")
        Else
            Console.WriteLine("Student not found.")
        End If
    End Sub

    Sub DisplayStudent()
        If studentCount = 0 Then
            Console.WriteLine("No students found.")
            Return
        End If

        Console.WriteLine("All Students:")
        For i As Integer = 0 To studentCount - 1
            Console.WriteLine($"Student ID: {students(i).StudentID}")
            Console.WriteLine($"Name: {students(i).FirstName} {students(i).LastName}")
            Console.WriteLine()
        Next
    End Sub
End Module