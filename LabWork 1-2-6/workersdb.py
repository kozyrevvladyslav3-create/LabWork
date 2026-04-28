N = 10
base_salary = []
rate = []
name = []

def amount_of_workers():
    i = 0
    count = 0
    while i == i:
        string = "Worker" + str(i)
        if string in globals():
            count += 1
        else:
            return count
        i += 1


def Worker0():
    base_salary_value = 30000 + N * 700
    rate_value = 0.75 + (N % 2 + N % 3) * 0.25
    name_value = "Антон Авдул"
    return base_salary_value, rate_value, name_value

def Worker1():
    base_salary_value = 9000 + N * 100
    rate_value = 0.5 - N * 0.01
    name_value = "Братислав Буряк"
    return base_salary_value, rate_value, name_value

def Worker2():
    base_salary_value = 175000 + N * 5000
    rate_value = 1.0
    name_value = "Станіслав Сірий"
    return base_salary_value, rate_value, name_value


for i in range(amount_of_workers()):
    string = "Worker" + str(i) + "()[" + str(0) + "]"
    base_salary.append(eval(string))
    string = "Worker" + str(i) + "()[" + str(1) + "]"
    rate.append(eval(string))
    string = "Worker" + str(i) + "()[" + str(2) + "]"
    name.append(eval(string))