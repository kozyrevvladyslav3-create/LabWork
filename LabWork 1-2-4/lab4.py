import dice as dc

die_sides = int(input("Введіть кількість сторін на кубиках:"))
dice_number = int(input("Введіть кількість кубиків:"))
modifier = int(input("Введіть модифікатор результату(Поставте 0 при відсутності):"))

def Report(cortege):
    if modifier < 0:
        nameplate = str(dice_number) + str("к") + str(die_sides) + str(modifier) + str(":")
    elif modifier > 0:
        nameplate = str(dice_number) + str("к") + str(die_sides) + str("+") + str(modifier) + str(":")
    else:
        nameplate = str(dice_number) + str("к") + str(die_sides) + str(":")

    print("Кидок кісток", nameplate)
    print(" Можливий діапазон [мін., сер., макс.]:", cortege[0])
    print(" Значення кісток:", cortege[1])
    print(" Результат:", cortege[2])

Report(dc.dice(die_sides, dice_number, modifier))