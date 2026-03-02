# BudgetWise - Personal Finance & Budget Tracker

This is the learning application for the GitHub Copilot Workshop (.NET Edition). BudgetWise is a personal finance and budget tracking application that allows users to manage their expenses, budgets, and financial goals.

## 🎯 Application Overview

BudgetWise is designed to help users:
- Track daily expenses and categorize them
- Set and monitor budgets for different spending categories
- Visualize spending patterns over time
- Export financial data for record-keeping

## 🛠️ Technology Stack

### Backend
- **.NET 8** - Modern, cross-platform framework
- **ASP.NET Core Web API** - RESTful API framework
- **C# 12** - Primary programming language
- In-memory data storage (mock data for development)

### Frontend
- **React 18** - UI library
- **TypeScript** - Type-safe JavaScript
- **Vite** - Build tool and dev server
- **Tailwind CSS** - Utility-first CSS framework
- **React Router** - Client-side routing
- **Lucide React** - Icon library

## 📁 Project Structure

```
budgetwise-app/
├── backend/                    # .NET Core API
│   ├── Controllers/           # API endpoint controllers
│   │   ├── AuthController.cs
│   │   ├── BudgetsController.cs
│   │   ├── CategoriesController.cs
│   │   ├── ExpensesController.cs
│   │   └── HealthController.cs
│   ├── Data/                  # Data access and mock data
│   │   └── MockData.cs
│   ├── Models/               # Data models and DTOs
│   │   ├── Budget.cs
│   │   ├── Category.cs
│   │   ├── DTOs.cs
│   │   ├── Expense.cs
│   │   ├── RecurringTransaction.cs
│   │   └── User.cs
│   ├── Services/             # Business logic
│   │   ├── AuthService.cs
│   │   ├── ExpenseRuleEngine.cs
│   │   └── ExpenseService.cs
│   ├── Properties/
│   ├── Program.cs            # Application entry point
│   ├── appsettings.json      # Configuration
│   └── BudgetWise.Api.csproj # Project file
│
└── frontend/                  # React TypeScript frontend
    ├── src/
    │   ├── components/       # Reusable UI components
    │   ├── context/          # React context providers
    │   │   └── AuthContext.tsx
    │   ├── hooks/            # Custom React hooks
    │   ├── pages/            # Page components
    │   │   ├── ExpensesPage.tsx
    │   │   └── LoginPage.tsx
    │   ├── services/         # API and data services
    │   │   ├── api.ts
    │   │   └── mockData.ts
    │   ├── types/            # TypeScript type definitions
    │   │   └── index.ts
    │   ├── App.tsx           # Main App component
    │   ├── App.css
    │   ├── index.css
    │   └── main.tsx
    ├── public/
    ├── package.json
    ├── tsconfig.json
    ├── vite.config.ts
    └── tailwind.config.js
```

## 🚀 Getting Started

### Prerequisites

- **.NET 8 SDK** or newer
- **Node.js 18** or newer
- **npm** (comes with Node.js)
- Visual Studio Code (recommended)

### Running the Backend

```bash
# Navigate to backend directory
cd budgetwise-app/backend

# Restore dependencies
dotnet restore

# Run the API (default port: 5000)
dotnet run
```

The API will be available at `http://localhost:5000`. Swagger UI is available at `http://localhost:5000/swagger`.

### Running the Frontend

```bash
# Navigate to frontend directory
cd budgetwise-app/frontend

# Install dependencies
npm install

# Start development server (default port: 5173)
npm run dev
```

The frontend will be available at `http://localhost:5173`.

### Demo Credentials

- **Username**: `demo`
- **Password**: `demo123`

## 📚 API Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/health` | GET | Health check |
| `/api/auth/login` | POST | Authenticate user |
| `/api/auth/me` | GET | Get current user |
| `/api/auth/logout` | POST | Logout user |
| `/api/expenses` | GET | Get all expenses |
| `/api/expenses/{id}` | GET | Get expense by ID |
| `/api/expenses` | POST | Create new expense |
| `/api/expenses/category/{category}` | GET | Get expenses by category |
| `/api/expenses/summary` | GET | Get expense summary |
| `/api/categories` | GET | Get all categories |

## 🎯 Pre-built Features

The following features are already implemented:

- ✅ Basic login page with authentication
- ✅ Health check endpoint
- ✅ Expenses list page with filtering
- ✅ Expense summary statistics
- ✅ Category filtering
- ✅ Responsive design with dark mode support

## 🔧 Unfinished Features (Lab Extension Points)

These features are marked with TODO comments for workshop labs:

### Lab 3 - CRUD Operations
- Complete Budget model
- Complete Category model
- Complete RecurringTransaction model
- Update and Delete expense endpoints
- Budget and Category CRUD endpoints

### Lab 4 - Charts & Analytics
- Spending over time chart data
- Budget progress tracking

### Lab 5 - Export Features
- CSV export functionality
- PDF export functionality

### Lab 6 - Rule Engine
- Expense validation rules
- "Flag expenses over $100" rule
- Duplicate expense detection
- Category limit alerts

## 🧪 Testing

### Backend
```bash
cd backend
dotnet test
```

### Frontend
```bash
cd frontend
npm run test
```

## 🏗️ Build for Production

### Backend
```bash
cd backend
dotnet publish -c Release
```

### Frontend
```bash
cd frontend
npm run build
```

## 📄 License

This project is licensed under the MIT License.
