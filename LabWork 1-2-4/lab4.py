import random

die_sides = int(input("Введіть кількість сторін на кубиках:"))
dice_number = int(input("Введіть кількість кубиків:"))
modifier = int(input("Введіть модифікатор результату(Поставте 0 при відсутності):"))

def dice():
    die_values = []
    die_values_sum = 0
    minimum = dice_number + modifier
    maximum = dice_number * die_sides + modifier
    average = (minimum + maximum) / 2
    theory = [minimum, average, maximum]
    for i in range(dice_number):
        value = random.randint(1, die_sides)
        die_values.append(value)
        die_values_sum += value
    final_sum = die_values_sum + modifier
    return theory, die_values, final_sum

def Report(theory, die_values, final_sum):
    if modifier < 0:
        nameplate = str(dice_number) + str("к") + str(die_sides) + str(modifier) + str(":")
    elif modifier > 0:
        nameplate = str(dice_number) + str("к") + str(die_sides) + str("+") + str(modifier) + str(":")
    else:
        nameplate = str(dice_number) + str("к") + str(die_sides) + str(":")

    print("Кидок кісток", nameplate)
    print(" Можливий діапазон [мін., сер., макс.]:", theory)
    print(" Значення кісток:", die_values)
    print(" Результат:", final_sum)

Report(*dice())