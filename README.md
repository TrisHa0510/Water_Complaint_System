# 💧 Water Complaint Management System

A comprehensive ASP.NET Core MVC web application for managing municipal water supply complaints. This system enables citizens to report water issues and allows municipal workers to track and resolve complaints efficiently.

[![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## 📋 Table of Contents

- [About The Project](#about-the-project)
- [Features](#features)
- [Built With](#built-with)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Database](#database)
- [API Endpoints](#api-endpoints)
- [Project Structure](#project-structure)
- [Practicals Covered](#practicals-covered)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## 🎯 About The Project

The *Water Complaint Management System* is a full-stack web application developed as part of the *Web Technology with .NET* course at Asha M. Tarsadia Institute of Computer Science and Technology. This project demonstrates all 15 practical exercises while addressing real-world municipal water management needs.

### Problem Statement

Citizens often face difficulties reporting water supply issues to municipal authorities, and tracking complaint resolution is challenging. This system provides a centralized platform for filing, tracking, and resolving water-related complaints.

### Solution

A complete web application with:
- Easy complaint filing by citizens
- Photo upload for evidence
- Real-time status tracking
- Municipal worker assignment
- Ward-based organization
- RESTful API for mobile integration

## ✨ Features

### For Citizens
- 📝 File water supply complaints online
- 📸 Upload photos of water issues
- 🔍 Track complaint status in real-time
- 🗺 Select ward/area for complaints
- ⚠ Set priority levels (Low, Medium, High, Critical)

### For Municipal Workers
- 👀 View all complaints by ward
- 🔄 Update complaint status (Pending, InProgress, Resolved, Rejected)
- ✅ Mark complaints as resolved
- 📊 Filter by status, priority, and ward
- 👷 Assign complaints to workers

### Technical Features
- 🔐 Session and cookie management
- 💾 Response caching for performance
- 🌐 RESTful Web API endpoints
- 📤 File upload functionality
- ✔ Model validation with data annotations
- 🎨 Custom CSS animations and Bootstrap 5 styling
- 📱 Fully responsive design
- 🗄 SQLite database (zero configuration)

## 🛠 Built With

*Backend:*
- ASP.NET Core MVC 8.0
- Entity Framework Core 8.0
- SQLite Database
- C# 12

*Frontend:*
- Razor Views (.cshtml)
- Bootstrap 5.3
- HTML5 / CSS3
- JavaScript

*Development Tools:*
- Visual Studio Code
- .NET CLI
- Git

## 🚀 Getting Started

### Prerequisites

Before you begin, ensure you have the following installed on your system:

1. **[.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)** or later
Verify installation
dotnet --version

Should output: 8.0.x or higher

2. **[Visual Studio Code](https://code.visualstudio.com/)** with C# extension
- Install C# Dev Kit extension from VS Code marketplace

3. **[Git](https://git-scm.com/downloads)** for version control

### Installation

Follow these steps to set up the project on your local machine:

#### Step 1: Clone the Repository
git clone https://github.com/yourusername/WaterComplaintSystem.git
cd WaterComplaintSystem

#### Step 2: Navigate to Project Directory

cd WaterComplaintSystem

#### Step 3: Restore NuGet Packages

dotnet restore

This command downloads all required dependencies specified in the project file.

#### Step 4: Install Entity Framework Tools

If you haven't installed Entity Framework Core tools globally, run:
dotnet tool install --global dotnet-ef

Verify installation:
dotnet ef --version

#### Step 5: Create the Database

Run the following commands to create and populate the SQLite database:
Create initial migration
dotnet ef migrations add InitialCreate

Apply migration to create database
dotnet ef database update


This will create a WaterComplaint.db file in your project directory with seed data including:
- ✅ 5 Wards (Central, North, East, South, West)
- ✅ 5 Municipal Workers (one per ward)
- ✅ 5 Citizens
- ✅ 5 Sample Complaints (various statuses and priorities)

#### Step 6: Create Required Folders

Create folders for storing images and uploaded files:

*Windows PowerShell:*
New-Item -ItemType Directory -Force -Path wwwroot\images
New-Item -ItemType Directory -Force -Path wwwroot\uploads\complaints

*macOS / Linux:*
mkdir -p wwwroot/images
mkdir -p wwwroot/uploads/complaints

#### Step 7: Add Greeting Images (Optional)

Place three image files in wwwroot/images/ for the time-based greeting feature:
- morning.jpg (bright/sunny image)
- afternoon.jpg (warm daytime image)  
- evening.jpg (sunset/dusk image)

You can download free images from [Unsplash](https://unsplash.com/) or [Pexels](https://pexels.com/), or skip this step (images will just not display).

### Running the Application

You can run the application using either the terminal or Visual Studio Code.

#### Option 1: Using Terminal (Command Line)

*Standard Run:*
dotnet run

*Run with Hot Reload (auto-restart on file changes):*
dotnet watch run

#### Option 2: Using Visual Studio Code

1. Open the project folder in VS Code
2. Press F5 or go to *Run → Start Debugging*
3. Select *.NET Core* if prompted
4. The application will start automatically

### Access the Application

Once running, open your browser and navigate to:

- *HTTP:* http://localhost:5000
- *HTTPS:* https://localhost:5001

*Note:* If you see a certificate warning for HTTPS, run this command to trust the development certificate:
dotnet dev-certs https --trust

### First-Time Usage

After launching the application:

1. ✅ Visit the *Home Page* to see the time-based greeting
2. ✅ Navigate to *Complaints* to view sample complaints
3. ✅ Click *Create New Complaint* to file a test complaint
4. ✅ Navigate to *Wards* to view ward information
5. ✅ Test the *API* at http://localhost:5000/api/api/complaints

## 🗄 Database

### Schema

The application uses *SQLite* with the following five tables:

| Table | Description |
|-------|-------------|
| *Wards* | Municipal ward information (name, area, description) |
| *Workers* | Municipal workers assigned to wards |
| *Citizens* | Citizens who file complaints |
| *Complaints* | Water supply complaints with status and priority |
| *ComplaintPhotos* | Photos uploaded with complaints |

### Relationships

- A *Ward* can have multiple *Complaints* and *Workers*
- A *Citizen* can file multiple *Complaints*
- A *Complaint* belongs to one *Ward* and one *Citizen*
- A *Complaint* can be assigned to one *Worker*
- A *Complaint* can have multiple *ComplaintPhotos*

### Database Location

The SQLite database file (WaterComplaint.db) is created in the project root directory. You can view and edit it using tools like:
- [DB Browser for SQLite](https://sqlitebrowser.org/)
- [SQLite Viewer (VS Code Extension)](https://marketplace.visualstudio.com/items?itemName=qwtel.sqlite-viewer)

## 🔌 API Endpoints

The application provides a RESTful API for mobile app integration.

*Base URL:* http://localhost:5000/api/api

### Complaints API

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/api/complaints | Get all complaints |
| GET | /api/api/complaints/{id} | Get single complaint by ID |
| POST | /api/api/complaints | Create new complaint |
| PUT | /api/api/complaints/{id} | Update existing complaint |
| DELETE | /api/api/complaints/{id} | Delete complaint |

### Wards API

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/api/wards | Get all wards |

### Example API Request

*Get All Complaints:*
curl -X GET http://localhost:5000/api/api/complaints

*Create New Complaint:*
curl -X POST http://localhost:5000/api/api/complaints
-H "Content-Type: application/json"
-d '{
"title": "Low water pressure",
"description": "Water pressure very low in my area",
"status": "Pending",
"priority": "Medium",
"citizenId": 1,
"wardId": 2
}'

## 📁 Project Structure
WaterComplaintSystem/
├── Controllers/ # MVC Controllers
│ ├── HomeController.cs # Home page & navigation
│ ├── ComplaintsController.cs # Complaint CRUD operations
│ ├── WardsController.cs # Ward management
│ └── ApiController.cs # REST API endpoints
├── Models/ # Data models (entities)
│ ├── Ward.cs
│ ├── Worker.cs
│ ├── Citizen.cs
│ ├── Complaint.cs
│ └── ComplaintPhoto.cs
├── Views/ # Razor views
│ ├── Home/ # Home page views
│ ├── Complaints/ # Complaint views
│ ├── Wards/ # Ward views
│ └── Shared/ # Shared layouts & partials
├── Data/ # Database context
│ └── ApplicationDbContext.cs # EF Core DbContext
├── Extensions/ # Extension methods
│ └── StringExtensions.cs # Badge styling extensions
├── wwwroot/ # Static files
│ ├── css/ # Stylesheets
│ ├── js/ # JavaScript files
│ ├── images/ # Images for greeting feature
│ └── uploads/ # User-uploaded files
├── Program.cs # Application entry point
├── appsettings.json # Configuration
└── WaterComplaintSystem.csproj

## 📚 Practicals Covered

This project demonstrates *all 15 practicals* from the Web Technology with .NET course:

| # | Practical | Implementation |
|---|-----------|----------------|
| 1 | Project setup with Terminal & VS Code | Configured ports 5000/5001 in Program.cs |
| 2 | Controllers and Views | HomeController.cs with custom MyView() |
| 3 | Time-based dynamic content | Good Morning/Afternoon/Evening greeting |
| 4 | Navigation and routing | Links between Index and Welcome pages |
| 5 | Bootstrap UI styling | Styled countries table |
| 6 | Models with nullable types | Nullable properties in models |
| 7 | Extension methods | StringExtensions.cs for badge styling |
| 8 | Async operations | All controller actions use async/await |
| 9 | Session, Cookies, Query strings | Filter storage and complaint tracking |
| 10 | Response caching | 60-second cache on Wards index |
| 11 | Entity Framework Core | SQLite with code-first approach |
| 12 | RESTful Web API | Complete CRUD API in ApiController.cs |
| 13 | ViewData, ViewBag, TempData | Used throughout home controller |
| 14 | Model validation | Data annotations and ModelState |
| 15 | Complete CRUD operations | Full CRUD for Complaints and Wards |

## 📸 Screenshots

### Home Page with Time-based Greeting
The home page dynamically displays "Good Morning", "Good Afternoon", or "Good Evening" based on the current time, along with an appropriate image.

### Complaint Management
View, create, edit, and delete water supply complaints with filtering by status, priority, and ward.

### Ward Management
Manage municipal wards with complaint and worker statistics.

### API Response
JSON API responses for mobile app integration.

## 🤝 Contributing

Contributions are welcome! If you'd like to improve this project:

1. Fork the repository
2. Create a feature branch (git checkout -b feature/AmazingFeature)
3. Commit your changes (git commit -m 'Add some AmazingFeature')
4. Push to the branch (git push origin feature/AmazingFeature)
5. Open a Pull Request

## 📝 License

Distributed under the MIT License. See LICENSE file for more information.

## 📧 Contact

*Your Name* - your.email@example.com

*Project Link:* https://github.com/yourusername/WaterComplaintSystem

## 🙏 Acknowledgments

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Bootstrap 5](https://getbootstrap.com)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [SQLite](https://www.sqlite.org)
- Asha M. Tarsadia Institute of Computer Science and Technology

---

*Made with ❤ for Web Technology with .NET Course | Academic Year 2025*

*Course:* Web Technology with .NET  
*Institution:* Asha M. Tarsadia Institute of Computer Science and Technology  
*Program:* Btech Information Technology (3rd Year).
