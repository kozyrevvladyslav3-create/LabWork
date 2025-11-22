grade1 = int(input("Enter your first grade:"))
grade2 = int(input("Enter your second grade:"))
grade3 = int(input("Enter your third grade:"))
grade4 = int(input("Enter your fourth grade:"))
grade5 = int(input("Enter your fifth grade:"))

if grade1 < 0 or grade2 < 0 or grade3 < 0 or grade4 < 0 or grade5 < 0:
    print("The grades must not be equal or less than 0")
else:
   result = float((grade1 + grade2 + grade3 + grade4 + grade5)/5)
   print ("Your average grade is:", result)