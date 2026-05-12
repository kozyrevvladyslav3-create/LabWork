import random

def dice(die_sides, dice_number, modifier):
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