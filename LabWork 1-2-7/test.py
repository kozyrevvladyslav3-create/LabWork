import requests

data = requests.get("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json").json()

data_dict = {dict_var["cc"]: dict_var["rate"] for dict_var in data}

print(data_dict)