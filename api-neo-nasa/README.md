
# ?? Potentially Hazardous Asteroids ??

#### Rafael Maestre del Río

___

## Index ??
+ **Explanation about the project**
+ **Example**


## Explanation ?
You need to make an End-Point that receives a day between **1 and 7**.
This endpoint must return a **list in a JSON format** with 3 biggest asteroids with **potentially hazardous impact on Earth** between Today and the Date obtained from add Today Date and Days variable in parameter.

endpoint Example: */asteroids?days=3*

**Important info**

1. Days Parameter its required. If it is not provided, must return a controlled error showing the error.
2. Days Parameter must be a value between 1 and 7. If it isn't API from Nasa must return a controller error.
3. Data must be obtained from next API, need to transform and construct the response with the next struct. StartDate is today date and EndDate its a calculated value adding parameter days to StartDate.

*https://api.nasa.gov/neo/rest/v1/feed?start_date=2021-12-09&end_date=2021-12-12&api_key=DEMO_KEY*


- Key values from NASA service to obtain results:
    + "is_potentially_hazardous_asteroid" = true.
    + "estimated_diameter:estimated_diameter_min" & "estimated_diameter:kilometers: estimated_diameter_max": To calculate the average.

JSON must return the next endpoint response:
- **nombre**: Obtained from "name",
- **diametro**: Average size calculated,
- **velocidad**: "close_approach_data:relative_velocity:kilometers_per_hour",
- **fecha**: "close_approach_data:close_approach_date",
- **planeta**: "close_approach_date:orbiting_body"



## ????? Example ?????
This example was in day 2023/05/15.

Example from this call to our API: *https://localhost/asteroids?days=7*

```json
[
    {
        "nombre": "387505 (1998 KN3)",
        "diametro": 0.8424470558,
        "velocidad": "144297.6121993399",
        "fecha": "2023-05-17",
        "planeta": "Earth"
    },
    {
        "nombre": "(2010 KB61)",
        "diametro": 0.3416194718,
        "velocidad": "82744.203133723",
        "fecha": "2023-05-21",
        "planeta": "Earth"
    },
    {
        "nombre": "(2022 UD9)",
        "diametro": 0.18773386305,
        "velocidad": "23950.9670359407",
        "fecha": "2023-05-16",
        "planeta": "Earth"
    }
]
```

