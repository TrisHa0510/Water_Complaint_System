<div align="center">

# 💧 Water Complaint Management System

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://asp.net/)
[![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)](https://www.sqlite.org/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)](https://getbootstrap.com/)

</div>

---

## 📖 Description

A modern *ASP.NET Core MVC* web application that enables citizens to report municipal water supply issues and allows municipal workers to efficiently track and resolve complaints.

### ✨ Key Features

🎨 *Beautiful UI* - Responsive design with Bootstrap 5  
📝 *File Complaints* - Citizens can submit water issues online with photo upload  
🔍 *Track Status* - Real-time complaint tracking (Pending → InProgress → Resolved)  
⚠ *Priority Levels* - Categorize complaints (Low, Medium, High, Critical)  
🏘 *Ward Management* - Organize complaints by municipal wards  
👷 *Worker Assignment* - Assign complaints to municipal workers  
🔌 *RESTful API* - Mobile app integration ready  
🗄 *Zero Configuration* - SQLite database (no server setup needed)  

### 🛠 Technology Stack

- *Backend:* ASP.NET Core MVC 8.0, C# 12
- *Database:* SQLite with Entity Framework Core 8.0
- *Frontend:* Razor Pages, Bootstrap 5.3, HTML5, CSS3, JavaScript
- *Tools:* Visual Studio Code, .NET CLI, Git

---

## 💻 Installation Steps

### 📋 Prerequisites

Before installation, ensure you have:

<table>
<tr>
<td width="33%" align="center">

*🔹 .NET 8.0 SDK*

[Download Here](https://dotnet.microsoft.com/download/dotnet/8.0)
dotnet --version
(Should show 8.0.x or higher)

</td>
<td width="33%" align="center">

*🔹 Visual Studio Code*

[Download Here](https://code.visualstudio.com/)

Install *C# Dev Kit* extension

</td>
<td width="33%" align="center">

*🔹 Git*

[Download Here](https://git-scm.com/)

For cloning repository

</td>
</tr>
</table>

---

### 📦 Installation Process

#### *Step 1: Clone the Repository*
git clone https://github.com/yourusername/WaterComplaintSystem.git
cd WaterComplaintSystem/WaterComplaintSystem

#### *Step 2: Restore NuGet Packages*
dotnet restore

#### *Step 3: Install Entity Framework Tools*
dotnet tool install --global dotnet-ef

#### *Step 4: Create & Populate Database*
Create migration
dotnet ef migrations add InitialCreate

Apply migration (creates WaterComplaint.db with seed data)
dotnet ef database update

> ✅ *Database Created!* Includes 5 Wards, 5 Workers, 5 Citizens, and 5 Sample Complaints

#### *Step 5: Create Upload Folders*

*Windows (PowerShell):*
New-Item -ItemType Directory -Force -Path wwwroot\images
New-Item -ItemType Directory -Force -Path wwwroot\uploads\complaints

*macOS / Linux:*
mkdir -p wwwroot/images wwwroot/uploads/complaints

#### *Step 6: Add Greeting Images* (Optional)

Place these files in wwwroot/images/:
- morning.jpg 🌅
- afternoon.jpg ☀
- evening.jpg 🌆

> 💡 Get free images from [Unsplash](https://unsplash.com/) or [Pexels](https://pexels.com/)

---

## 🚀 How to Run the Project

### Method 1: Run from Terminal

<table>
<tr>
<td width="50%">

*Standard Run:*
dotnet run

</td>
<td width="50%">

*Run with Hot Reload:*
dotnet watch run
Auto-restarts on file changes

</td>
</tr>
</table>

### Method 2: Run from Visual Studio Code

1. Open the project folder in VS Code
2. Press **F5** or go to *Run → Start Debugging*
3. Select **.NET Core** if prompted
4. Application starts automatically! 🎉

---

### 🌐 Access the Application

<div align="center">

Once the application is running, open your browser:

## 🔗 [http://localhost:5000](http://localhost:5000)

*or*

## 🔐 [https://localhost:5001](https://localhost:5001)

---

> ⚠ *HTTPS Certificate Warning?*  
> Run this command to trust the development certificate:
> 
> dotnet dev-certs https --trust
> 

</div>

---

### 🎯 Quick Test

<div align="center">

*Try These Features:*

| Feature | URL/Action |
|---------|-----------|
| 🏠 *Home Page* | See time-based greeting (Good Morning/Afternoon/Evening) |
| 📋 *View Complaints* | Browse pre-loaded sample complaints |
| ➕ *Create Complaint* | Click "Create New Complaint" button |
| 🏘 *Manage Wards* | Navigate to Wards section |
| 🔌 *Test API* | Visit http://localhost:5000/api/api/complaints |

</div>

---

<div align="center">

### 🎓 Academic Project

*Course:* Web Technology with .NET  
*Institution:* Asha M. Tarsadia Institute of Computer Science and Technology  
*Program:* B.E. Software Engineering (3rd Year) | *Year:* 2024-2025

---

*Built with 💧 for Community Service*

[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/yourusername/WaterComplaintSystem)

</div>
