using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDriver
{
    public class Employee_Hierarchy
    {
        public static string csvPath = @"F:TechnoBrain\Repo\Employees.csv";
        public static string response = string.Empty;
        //long salaryBudget = fn_GetSalaryBudgetForManager("Employee1", csvPath);

        public static string fn_EmployeeHierarchy(string csvPath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(csvPath))
                {
                    string currentLine = string.Empty;// currentLine will be null when the StreamReader reaches the end of file
                    string employeeID = string.Empty;
                    string managerID = string.Empty;
                    string employeeSalary = string.Empty;
                    int ceoCount = 0;
                    bool isManagerEmployee = false;

                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        //Display line by line
                        currentLine = currentLine.Replace("\\", "");
                        currentLine = currentLine.Replace("\"", "");
                        Console.WriteLine(currentLine);

                        string[] columns = currentLine.Split(',');
                        employeeID = columns[0];
                        managerID = columns[1];
                        employeeSalary = columns[2];

                        //validatation

                        //1.The salaries in the CSV are valid integer numbers. 
                        bool isParamenteredaNumber = IsNumeric(employeeSalary);

                        if (isParamenteredaNumber == false)
                        {
                            Console.WriteLine("*********************************************");
                            response = "employeeSalary Is Not Integer Number";
                            Console.WriteLine("employeeSalary Is Not Integer Number");
                            Console.WriteLine("*********************************************");
                            Console.WriteLine();
                        }
                        else if (columns.Length > 4) // 2. One employee does not report to more than one manager.
                        {
                            Console.WriteLine("*********************************************");
                            response = "employee reports to more than one manager";
                            Console.WriteLine("employee reports to more than one manager");
                            Console.WriteLine("*********************************************");
                            Console.WriteLine();
                        }
                        else if (managerID == "") // 3. There is only one CEO, i.e. only one employee with no manager.
                        {
                            ceoCount = ceoCount + 1;
                            if (ceoCount > 1)
                            {
                                Console.WriteLine("*********************************************");
                                response = "There should only be one CEO, i.e. only one employee with no manager";
                                Console.WriteLine("There should only be one CEO, i.e. only one employee with no manager");
                                Console.WriteLine("*********************************************");
                                Console.WriteLine();
                            }
                        }
                        else if (employeeID == managerID)// 4. There is no circular reference, i.e. a first employee reporting to a second employee that is also under the first employee.
                        {
                            Console.WriteLine("*********************************************");
                            response = "No employee should report to themselves";
                            Console.WriteLine("No employee should report to themselves");
                            Console.WriteLine("*********************************************");
                            Console.WriteLine();
                        }
                        else if (!String.IsNullOrEmpty(managerID)) // 5. There is no manager that is not an employee, i.e. all managers are also listed in the employee column.
                        {
                            var fullEmployeelist = new List<string>();
                            fullEmployeelist = fn_GetAllEmployeeList(csvPath);
                            foreach (var Employee in fullEmployeelist)
                            {
                                if (managerID == Employee)
                                {
                                    isManagerEmployee = true;
                                }
                            }
                            if (isManagerEmployee == false)
                            {
                                Console.WriteLine("*********************************************");
                                response = "The manager should be an employee";
                                Console.WriteLine("The manager should be an employee");
                                Console.WriteLine("*********************************************");
                                Console.WriteLine();
                            }
                        }
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.ReadLine();
                }
                return response;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return response;
            }
        }

        public static string fn_ValidateSalary(string csvPath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(csvPath))
                {
                    string currentLine = string.Empty;// currentLine will be null when the StreamReader reaches the end of file
                    string employeeID = string.Empty;
                    string managerID = string.Empty;
                    string employeeSalary = string.Empty;

                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        //Display line by line
                        currentLine = currentLine.Replace("\\", "");
                        currentLine = currentLine.Replace("\"", "");
                        Console.WriteLine(currentLine);

                        string[] columns = currentLine.Split(',');
                        employeeID = columns[0];
                        managerID = columns[1];
                        employeeSalary = columns[2];

                        //validatation

                        //1.The salaries in the CSV are valid integer numbers. 
                        bool isParamenteredaNumber = IsNumeric(employeeSalary);

                        if (isParamenteredaNumber == false)
                        {
                            Console.WriteLine("*********************************************");
                            response = "employeeSalary Is Not Integer Number";
                            Console.WriteLine("employeeSalary Is Not Integer Number");
                            Console.WriteLine("*********************************************");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.ReadLine();
                }
                return response;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return response;
            }
        }

        public static string fn_ValidateReportingToManager(string csvPath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(csvPath))
                {
                    string currentLine = string.Empty;// currentLine will be null when the StreamReader reaches the end of file
                    string employeeID = string.Empty;
                    string managerID = string.Empty;
                    string employeeSalary = string.Empty;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        //Display line by line
                        currentLine = currentLine.Replace("\\", "");
                        currentLine = currentLine.Replace("\"", "");
                        Console.WriteLine(currentLine);

                        string[] columns = currentLine.Split(',');
                        employeeID = columns[0];
                        managerID = columns[1];
                        employeeSalary = columns[2];

                        //validatation

                        if (columns.Length > 4) // 2. One employee does not report to more than one manager.
                        {
                            Console.WriteLine("*********************************************");
                            response = "employee reports to more than one manager";
                            Console.WriteLine("employee reports to more than one manager");
                            Console.WriteLine("*********************************************");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.ReadLine();
                }
                return response;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return response;
            }
        }

        public static string fn_ValidateCEOcount(string csvPath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(csvPath))
                {
                    string currentLine = string.Empty;// currentLine will be null when the StreamReader reaches the end of file
                    string employeeID = string.Empty;
                    string managerID = string.Empty;
                    string employeeSalary = string.Empty;
                    int ceoCount = 0; 

                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        //Display line by line
                        currentLine = currentLine.Replace("\\", "");
                        currentLine = currentLine.Replace("\"", "");
                        Console.WriteLine(currentLine);

                        string[] columns = currentLine.Split(',');
                        employeeID = columns[0];
                        managerID = columns[1];
                        employeeSalary = columns[2];

                        //validatation
                        if (managerID == "") // 3. There is only one CEO, i.e. only one employee with no manager.
                        {
                            ceoCount = ceoCount + 1;
                            if (ceoCount > 1)
                            {
                                Console.WriteLine("*********************************************");
                                response = "There should only be one CEO, i.e. only one employee with no manager";
                                Console.WriteLine("There should only be one CEO, i.e. only one employee with no manager");
                                Console.WriteLine("*********************************************");
                                Console.WriteLine();
                            }
                        }
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.ReadLine();
                }
                return response;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return response;
            }
        }

        public static List<string> fn_GetAllEmployeeList(string csvPath)
        {
            List<string> employeeList = new List<string>();
            using (var reader = new StreamReader(csvPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    employeeList.Add(values[0].Replace("\\", "").Replace("\"", ""));
                }
            }
            return employeeList;
        }

        public static long fn_GetSalaryBudgetForManager(string ManagerID, string csvPath)
        {
            List<string> managerList = new List<string>();
            bool isValidManager = false;
            int currSal = 0;
            int salarySum = 0;

            using (StreamReader sr = new StreamReader(csvPath))
            {
                string currentLine = string.Empty;// currentLine will be null when the StreamReader reaches the end of file 
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string currEmployeeID = string.Empty;
                    string currManagerID = string.Empty;
                    string currEmployeeSalary = string.Empty;

                    currentLine = currentLine.Replace("\\", "");
                    currentLine = currentLine.Replace("\"", "");
                    string[] columns = currentLine.Split(',');
                    currEmployeeID = columns[0];
                    currManagerID = columns[1];
                    currEmployeeSalary = columns[2];

                    if (currManagerID == ManagerID || currManagerID == "")
                    {
                        currSal = currSal + Convert.ToInt16(currEmployeeSalary);
                        salarySum = currSal;
                    }
                    if (currEmployeeID == ManagerID)
                    {
                        salarySum = salarySum + Convert.ToInt16(currEmployeeSalary);
                    }
                }
            }
            Console.WriteLine("*********************************************");
            Console.WriteLine(salarySum);
            Console.WriteLine("*********************************************");
            Console.WriteLine();
            return salarySum;
        }

        //To do Numeric Validation
        public static bool IsNumeric(object enteredNumber)
        {
            double retNum;
            bool isParamenteredaNumber = Double.TryParse(Convert.ToString(enteredNumber), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isParamenteredaNumber;
        }
    }

}
