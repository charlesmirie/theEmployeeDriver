# theEmployeeDriver
Create a constructor that takes a CSV1 input string containing a list of employee info and validates the string. The first CSV column contains the id of the employee, the second one contains the id of the manager, and the third one contains the employee’s salary. The CEO of the company is the only employee that doesn't have a manager; in his case, the manager field will be empty. The list is not guaranteed to be sorted and can come in any random order. See the example below.

The constructor should validate that:
1. The salaries in the CSV are valid integer numbers.
2. One employee does not report to more than one manager.
3. There is only one CEO, i.e. only one employee with no manager.
4. There is no circular reference, i.e. a first employee reporting to a second employee that is also under the first employee.
5. There is no manager that is not an employee, i.e. all managers are also listed in the employee column.

Add an instance method that returns the salary budget from the specified manager. The salary budget from a manager is defined as the sum of the salaries of all the employees reporting (directly or indirectly) to a specified manager, plus the salary of the manager
