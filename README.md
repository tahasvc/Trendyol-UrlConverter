
# Trendyol Case (Link Converter)
- A web service that helps others convert their Trendyol.com links between mobile and mobile.
- This service, when you want to route between applications converts URLs to deep links or deep links to URLs.

## Running with Docker
- Prerequisites [Docker](https://www.docker.com/)
- `git clone https://github.com/DevelopmentHiring/TrendyolCase-TahaSivaci.git`
- `cd TrendyolCase-TahaSivaci`
- `docker-compose up --build`
- Navigate to http://localhost:5000/swagger

## How to Use

  There are 2 API's for converting links. `localhost:5000/`

* `/api/todeeplink`

   API Accepts <strong>POST</strong> request. Given Web URL in <strong>JSON</strong> object with parameter `link`.

   Example request body:  
    ```
    {
      "link": "https://www.trendyol.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064"
    }
    ```

   Response:
    ```
    {
      "link": "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064"
    }
    ```


* `/api/toweblink`

   API Accepts <strong>POST</strong> request. Given deeplink in <strong>JSON</strong> object with parameter "link".

   Example request body:
    ```
    {
      "link": "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064"
    }
    ```
   Response:
    ```
    {
      "link": "https://www.trendyol.com/brand/name-p1925865?boutiqueId=439892&merchantId=105064"
    }
    ```
