# ASP.NET Core MVC 練習專案

這是一個使用 ASP.NET Core MVC 架構的練習專案，包含多項功能，旨在整合前後端開發、資料庫應用與 Python 模型服務串接。
<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-blueviolet.svg?logo=dotnet&logoColor=white" alt=".NET">
  <img src="https://img.shields.io/badge/Python-3.10-blue.svg?logo=python&logoColor=white" alt="Python">
  <img src="https://img.shields.io/badge/FastAPI-009688.svg?logo=fastapi&logoColor=white" alt="FastAPI">
  <img src="https://img.shields.io/badge/SQLServer-%23CC2927.svg?logo=microsoftsqlserver&logoColor=white" alt="SQL Server">
  <img src="https://img.shields.io/badge/Google%20Calendar-4285F4.svg?logo=googlecalendar&logoColor=white" alt="Google Calendar">
</p>

## 🔧 功能列表

1. 🗨️ **留言板系統**
   - 使用 MSSQL 作為資料庫
   - 使用 Entity Framework Core 進行資料庫操作

2. 📅 **與 Google 日曆連動**
   - 使用 Google Calendar API
   - 可顯示與操作使用者日曆資料

3. 🖼️ **簡單影像處理功能**
   - 支援圖片縮放
   - 支援圖片轉灰階處理

4. 🤖 **整合 FastAPI + ResNet 模型**
   - 透過 FastAPI 建立 Python Web API
   - ASP.NET Core MVC 呼叫 Python API 進行 ResNet 二元分類
   - 支援使用者上傳圖片並回傳預測結果


## 🧰 使用技術

| 技術 | 說明 |
|------|------|
| **ASP.NET Core MVC** | 處理網站後端邏輯與頁面渲染 |
| **MSSQL** | 資料儲存，使用 Entity Framework 互動 |
| **HTML/CSS/JavaScript** | 建構網頁前端與使用者互動 |
| **FastAPI** | 建立 Python API 串接深度學習模型 |
| **Python + ResNet** | 執行影像分類模型 |
| **Google Calendar API** | 與 Google 日曆串接，實現行事曆功能 |
