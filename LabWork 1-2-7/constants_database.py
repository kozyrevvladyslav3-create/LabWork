import requests

PERSONAL_INCOME_TAX_RATE = 0.18 #ПДФО

MILITARY_TAX_RATE = 0.05 #ВЗ

SINGLE_CONTRIBUTION_TAX_RATE = 0.22 #ЄСВ

SINGLE_CONTRIBUTION_BASE_MIN = 1902.34
SINGLE_CONTRIBUTION_BASE_MAX = 38046.8

MINIMUM_SALARY = 8647

EURO_MINIMUM_SALARY = 1200
HRYVNA_TO_EURO_RATE = {dict_var["cc"]: dict_var for dict_var in requests.get("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json").json()}["EUR"]['rate']
DIYA_MINIMUM_SALARY = EURO_MINIMUM_SALARY * HRYVNA_TO_EURO_RATE

AMOUNT_OF_WORKERS_MINIMUM = 9