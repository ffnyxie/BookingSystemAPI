# 📚 BookingSystemAPI - API 文件

## 📌 API Base URL
https://localhost:7227/BookingSystemAPI

---

## 🔸 1. 建立訂位
- **方法**：`POST`
- **URL**：`/BookingSystemAPI`
- 
- **Request Body**（JSON 範例）：
```json
{
  "id": 0,
  "name": "小白",
  "phone": "0900123123",
  "email": "123d@gmail.com",
  "numberOfPeople": 2,
  "bookingDateTime": "2025-06-10T14:04:29.639Z",
  "specialNote": "約會"
}
```
成功回傳（200 OK）：
```json
{
  "id": 1,
  "name": "小白",
  "phone": "0900123123",
  "email": "123d@gmail.com",
  "numberOfPeople": 2,
  "bookingDateTime": "2025-06-10T14:04:29.639Z",
  "specialNote": "約會"
}
```
錯誤回傳（400 Bad Request）：ModelState 驗證失敗（例如資料格式錯誤或必填欄位未填）。

## 🔸2.取得所有訂位
**方法**：GET
**URL**：/BookingSystemAPI

**成功回傳（200 OK）**：
```json
[
  {
    "id": 1,
    "name": "小白",
    "phone": "0900123123",
    "email": "123d@gmail.com",
    "numberOfPeople": 2,
    "bookingDateTime": "2025-06-10T14:04:29.639Z",
    "specialNote": "約會"
  }
  ```

## 🔸3.取得單筆訂位
**方法**：GET
**URL**：/BookingSystemAPI/{id}

**成功回傳**（200 OK）：
```json
{
  "id": 1,
  "name": "小白",
  "phone": "0900123123",
  "email": "123d@gmail.com",
  "numberOfPeople": 2,
  "bookingDateTime": "2025-06-10T14:04:29.639Z",
  "specialNote": "約會"
}
```
**錯誤回傳**（404 Not Found）：
```json
"查無此訂位"
```

## 4.修改訂位
**方法**：PUT
**URL**：/BookingSystemAPI/{id}

**Request Body（JSON）**：
```json
{
  "name": "小白（修改後）",
  "phone": "0911222333",
  "email": "updated@example.com",
  "numberOfPeople": 3,
  "bookingDateTime": "2025-06-10T18:00:00.000Z",
  "specialNote": "改靠窗"
}
```
成功回傳（200 OK）：同 POST 回傳格式。

## 🔸5.刪除訂位
**方法**：DELETE
**URL**：/BookingSystemAPI/{id}

**成功回傳（200 OK）**：被刪除的資料（JSON）

**錯誤回傳（404 Not Found）**：
```json
"查無此訂位"
```


## 🔸 Model 欄位（BookingModel）
欄位名稱	        型別	    備註
id	                int	    系統自動產生
name	            string	    必填
phone	            string	    必填、格式驗證
email	            string	    選填
numberOfPeople	    int	    必填、範圍 1~10
bookingDateTime	    DateTime	必填
specialNote	string	        選填

## 📝 備註
所有 API 回傳格式皆為 JSON。
需先啟動 ASP.NET Core 專案（dotnet run）。
本專案資料存在後端記憶體，若重新啟動資料會遺失。
僅作為展示專案之用。

## 🚀 推薦使用方式
啟動專案（dotnet run）
使用 Swagger UI、Postman 或 curl 測試 API
參考此文件進行測試