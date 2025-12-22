def geometric_term(a1, q, n):
    if n == 1:
        return a1
    return geometric_term(a1, q, n - 1) * q

def geometric_sum(a1, q, n):
    if n == 1:
        return a1
    return geometric_sum(a1, q, n - 1) + geometric_term(a1, q, n)

a1 = float(input("Веедіть перший член геометричної прогресії:"))
q = float(input("Веедіть значення геометричної прогрессії:"))
n = int(input("Веедіть номер шуканого члену геометричної прогресії:"))

print("n-й член прогресії:", geometric_term(a1, q, n))
print("Сума перших n членів:", geometric_sum(a1, q, n))