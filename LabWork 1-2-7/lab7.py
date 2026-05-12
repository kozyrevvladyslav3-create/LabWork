import constants_database as db
import workersdb as w


is_diya_resident = int(input("Чи ви є Резидентом Дія Сіті?(0 - ні, 1 - так):"))

accrued_salary_list = []
accrued_salary_total = 0

personal_income_tax_list = []
personal_income_tax_total = 0

single_contribution_amount_total = 0

net_salary_total = 0

employee_cost_total = 0

personal_income_tax_penalty_rate = 0


def accrued_salary(base_salary, rate):
    return base_salary * rate

def personal_income_tax_amount(accrued_salary_operand):
    if is_diya_resident == 1:
        personal_income_tax_rate = db.PERSONAL_INCOME_TAX_RATE_DIYA
    else:
        personal_income_tax_rate = db.PERSONAL_INCOME_TAX_RATE
    return accrued_salary_operand * personal_income_tax_rate + accrued_salary_operand * personal_income_tax_penalty_rate

def military_tax_amount(accrued_salary_operand):
    return accrued_salary_operand * db.MILITARY_TAX_RATE

def single_contribution_amount(accrued_salary_operand):
    single_contribution_amount_operand = accrued_salary_operand * db.SINGLE_CONTRIBUTION_TAX_RATE
    if (single_contribution_amount_operand) < db.SINGLE_CONTRIBUTION_BASE_MIN:
        (single_contribution_amount_operand) = db.SINGLE_CONTRIBUTION_BASE_MIN
    elif (single_contribution_amount_operand) > db.SINGLE_CONTRIBUTION_BASE_MAX:
        (single_contribution_amount_operand) = db.SINGLE_CONTRIBUTION_BASE_MAX
    return single_contribution_amount_operand

def net_salary(accrued_salary_operand, personal_income_tax_amount_operand, military_tax_amount_operand):
    return accrued_salary_operand - (personal_income_tax_amount_operand + military_tax_amount_operand) + accrued_salary_operand * personal_income_tax_penalty_rate

def employee_cost(accrued_salary_operand, single_contribution_amount_operand):
    return accrued_salary_operand + single_contribution_amount_operand

def Worker_report(base_salary, rate, name):
    print("\nОбрахунок:", name, "\n")

    accrued_salary_operand = accrued_salary(base_salary, rate)
    print("Нарахована зарплата:", f"{accrued_salary_operand:.2f}", "грн.")
    accrued_salary_list.append(accrued_salary_operand)

    global personal_income_tax_penalty_rate
    personal_income_tax_amount_operand = personal_income_tax_amount(accrued_salary_operand)
    if personal_income_tax_penalty_rate > 0:
        text = "Сума ПДФО(Включаючи штраф за рахунок підприємства):"
    else:
        text = "Сума ПДФО:"
    print(text, f"{personal_income_tax_amount_operand:.2f}", "грн.")
    personal_income_tax_list.append(personal_income_tax_amount_operand)
    global personal_income_tax_total
    personal_income_tax_total += personal_income_tax_amount_operand

    military_tax_amount_operand = military_tax_amount(accrued_salary_operand)
    print("Сума ВЗ:", f"{military_tax_amount_operand:.2f}", "грн.")

    single_contribution_amount_operand = single_contribution_amount(accrued_salary_operand)
    print("Сума ЄСВ:", f"{single_contribution_amount_operand:.2f}", "грн.")
    global single_contribution_amount_total
    single_contribution_amount_total += single_contribution_amount_operand

    net_salary_operand = net_salary(accrued_salary_operand, personal_income_tax_amount_operand, military_tax_amount_operand)
    print("Зарплата до виплати:", f"{net_salary_operand:.2f}", "грн.")
    global net_salary_total
    net_salary_total += net_salary_operand

    employee_cost_operand = employee_cost(accrued_salary_operand, single_contribution_amount_operand)
    print("Загальні витрати підприємства на оплату праці цього працівника:", f"{employee_cost_operand:.2f}", "грн.")
    global employee_cost_total
    employee_cost_total += employee_cost_operand

def reports_totals():
    print("\nСписок нарахованих заробітних плат:\n", accrued_salary_list, "\n", w.name, "\n")

    if (w.amount_of_workers() < db.AMOUNT_OF_WORKERS_MINIMUM) and (is_diya_resident == 1):
        print("Увага! Недостатня кількість працівників!", "(", w.amount_of_workers(), "/", db.AMOUNT_OF_WORKERS_MINIMUM, ")")
    else:
        global average_salary
        print("Середня місячна заробітня плата по підприємству:", f"{average_salary:.2f}", "\n")
        
        print("Сума нарахованих заробітних плат:", f"{net_salary_total:.2f}")
        print("Сума ПДФО:", f"{personal_income_tax_total:.2f}")
        print("Сума ЄСВ:", f"{single_contribution_amount_total:.2f}")

        print("\nПорівняння середньої заробітної плати підприємства до вимог сердньї заробітної плати Дія Сіті:\n")
        print(f"{db.EURO_MINIMUM_SALARY:.2f}", "/", f"{(average_salary / db.HRYVNA_TO_EURO_RATE):.2f}", "в Євро")
        print(f"{db.DIYA_MINIMUM_SALARY:.2f}", "/", f"{average_salary:.2f}", "В Гривнях")

        print("\nЗагальні витрати підприємства на оплату праці всіх працівників:", f"{employee_cost_total:.2f}")

def average_salary_check():
    global accrued_salary_total
    global average_salary
    for i in range(w.amount_of_workers()):
        accrued_salary_total += accrued_salary(w.base_salary[i], w.rate[i])
    average_salary = accrued_salary_total / w.amount_of_workers()
    if is_diya_resident == 1:
        global personal_income_tax_penalty_rate
        if average_salary < db.DIYA_MINIMUM_SALARY:
            personal_income_tax_penalty_rate = db.PENALTY

average_salary_check()

for i in range(w.amount_of_workers()):
    Worker_report(w.base_salary[i], w.rate[i], w.name[i])

reports_totals()