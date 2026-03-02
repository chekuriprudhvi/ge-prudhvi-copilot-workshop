# Exercise 1 - Lab Overview and Setup

#### Duration: 15 minutes

## Overall Lab Objectives

These hands-on labs are designed to give developers practical experience using **GitHub Copilot** as an AI-powered assistant throughout the Software Development Life Cycle (SDLC). You will explore how GitHub Copilot can improve developer productivity, code quality, and collaboration—from feature planning and prototyping to implementation, code review, and customization.

Through a series of guided, real-world exercises, you will learn how to:

-   Understand GitHub Copilot's role across all phases of the SDLC
-   Use AI-powered code completions directly within the IDE
-   Leverage GitHub Copilot Chat in Ask, Edit, and Agent modes
-   Explore GitHub Copilot Spaces for collaborative development
-   Delegate tasks to the GitHub Copilot coding agent to multiply development impact
-   Optimize GitHub Copilot performance using Custom Instructions and Prompt Files
-   Understand engineering best practices for AI-assisted development

> [!IMPORTANT]
> Throughout this lab you will work on a variety of tasks using your new best friend GitHub Copilot. At times there may be things that don't work as expected, and that's ok! Copilot is here to help in all aspects of our work. So if you encounter an issue while working through a lab try asking Copilot if it can help you solve the problem. Throw the error message into the chat, or link Copilot to a problem in the command line output. You might be surprised at the things Copilot is able to help you solve.

## Welcome to BudgetWise

💰 **Your Mission: Transforming how people manage their personal finances**

Congratulations! You've just been hired as a software developer at **BudgetWise**, an innovative fintech startup that's revolutionizing personal finance management. Your company specializes in helping users track expenses, set budgets, and achieve their financial goals.

### Your Role

As a new developer on the team, you'll be working on extending the functionality of the BudgetWise application and ensuring that it follows best practices. The company has recently adopted **GitHub Copilot** as part of its development workflow, and you'll be learning how to leverage this AI-powered assistant to accelerate your productivity and code quality.

### The Challenge Ahead

Throughout this lab, you'll help BudgetWise tackle real development challenges:

-   Understanding and navigating the existing .NET and React codebase effectively
-   Enhancing features across critical application components (expenses, budgets, categories)
-   Planning and implementing new financial tracking features and functionality
-   Maintaining high code quality standards across the development team
-   Collaborating effectively using AI-assisted development tools

Your manager has emphasized that delivering great user experiences is crucial in the competitive fintech space, but code quality and developer productivity cannot be compromised. This is where GitHub Copilot becomes your secret weapon—helping you build better features faster while maintaining the high standards that users expect from BudgetWise.

Let's get started and create something amazing! 💰

## Setting up Your Development Environment

The first thing to do is to make sure that you create your own copy of this repository so that you can keep all of the work you do in this training.

This repository is set up as a template, so you can easily create your own copy from it!

1. From the `Code` tab of the repository click the green `Use this template` button in the top right.
2. Select `Create a new repository`
3. Here you select how you want to create the repository.
    - Owner: select either yourself or an organization you have access to
    - Visibility: select whatever option you prefer. (Note: for users in an EMU you will not be able to select public as an option)
    - Do not input anything for the Copilot prompt

---

## Exercise 1: Environment Setup

### Option A: GitHub Codespaces (Recommended)

The fastest way to get started is using GitHub Codespaces:

1. Navigate to the repository on GitHub
2. Click the **"Code"** button on the repository page
3. Select the **"Codespaces"** tab
4. Click **"Create codespace on main"** (or your current branch)
5. Wait for the codespace to build and start

The codespace will automatically:

-   Configure GitHub Copilot and essential VS Code extensions
-   Provide a fully configured development environment
-   Install .NET 8 SDK and Node.js 18
-   Restore NuGet packages for the backend
-   Install npm dependencies for the frontend

### Using VS Code Tasks to Run Servers

This repository includes pre-configured VS Code tasks for running the application. The servers are configured to **start automatically** when you open the workspace. If they don't start automatically, or if you need to restart them, you can use VS Code tasks:

#### Running Both Servers Together

1. Press `Ctrl+Shift+P` (Windows/Linux) or `Cmd+Shift+P` (Mac) to open the Command Palette
2. Type **"Tasks: Run Task"** and select it
3. Choose **"Start Full Application"**
4. Both servers will start in separate terminal windows

#### Running Servers Individually

1. Press `Ctrl+Shift+P` / `Cmd+Shift+P` to open the Command Palette
2. Type **"Tasks: Run Task"** and select it
3. Choose either:
    - **"Start Backend API"** - Starts the .NET API on port 5000
    - **"Start Frontend Dev Server"** - Starts the React dev server on port 5173

#### Keyboard Shortcut

You can also use `Ctrl+Shift+B` / `Cmd+Shift+B` to quickly access build tasks.

> **💡 Tip:** The terminal panels for each server will remain open, showing logs and any errors. You can switch between them using the terminal dropdown in the panel.

### Manual Start (Alternative)

If you prefer to start the servers manually via command line:

**Backend:**

```bash
cd budgetwise-app/backend
dotnet run
```

**Frontend (in a new terminal):**

```bash
cd budgetwise-app/frontend
npm run dev
```

Access the application at the forwarded port URL provided in the terminal (typically `http://localhost:5173` for frontend, `http://localhost:5000` for backend API).

### Option B: Local Development

If you prefer to work locally:

1. **Prerequisites:**

    - .NET 8 SDK or newer
    - Node.js 18 or newer
    - npm (comes with Node.js)
    - Git
    - Visual Studio Code (recommended)

2. **Clone the repository:**

    ```bash
    git clone https://github.com/<YOURORGANIZATION>/<YOURREPOSITORYNAME>.git
    cd <YOURREPOSITORYNAME>
    ```

3. **Install backend dependencies:**

    ```bash
    cd budgetwise-app/backend
    dotnet restore
    ```

4. **Install frontend dependencies:**

    ```bash
    cd ../frontend
    npm install
    ```

5. **Start the backend:**

    ```bash
    cd ../backend
    dotnet run
    ```

6. **Start the frontend (new terminal):**

    ```bash
    cd budgetwise-app/frontend
    npm run dev
    ```

7. **Open the application:**
    - Frontend: [http://localhost:5173](http://localhost:5173)
    - Backend API: [http://localhost:5000](http://localhost:5000)
    - Swagger UI: [http://localhost:5000/swagger](http://localhost:5000/swagger)

## Installing GitHub Copilot

1. **Open Visual Studio Code** (or your codespace)

2. **Install the GitHub Copilot extension:**

    - Click on the **Extensions** icon in the left sidebar (or press `Ctrl+Shift+X` / `Cmd+Shift+X`)
    - Search for **"GitHub Copilot"**
    - Click **Install** on the "GitHub Copilot" extension
    - Also install **"GitHub Copilot Chat"** if not automatically installed

3. **Sign in to GitHub:**

    - When prompted, sign in to your GitHub account
    - Authorize the GitHub Copilot extension

4. **Verify installation:**
    - Look for the GitHub Copilot icon in the bottom-right status bar
    - Open the Copilot Chat panel (click the chat icon in the left sidebar or use the keyboard shortcut)
    - You should see the chat interface ready to use

## Exploring the Application

Now that your environment is set up, let's explore what you'll be working with:

1. **View the running application:**

    - Open [http://localhost:5173](http://localhost:5173) in your browser
    - Log in with demo credentials (username: `demo`, password: `demo123`)
    - Explore the Expenses page to see the list of expenses
    - Try filtering expenses by category
    - Examine the expense summary statistics

2. **Explore the codebase structure:**

    ```
    budgetwise-app/
    ├── backend/                    # .NET Core Web API
    │   ├── Controllers/           # API endpoint controllers
    │   │   ├── AuthController.cs
    │   │   ├── BudgetsController.cs
    │   │   ├── CategoriesController.cs
    │   │   ├── ExpensesController.cs
    │   │   └── HealthController.cs
    │   ├── Data/                  # Mock data
    │   │   └── MockData.cs
    │   ├── Models/               # Data models and DTOs
    │   ├── Services/             # Business logic
    │   ├── Program.cs            # Application entry point
    │   └── BudgetWise.Api.csproj # Project file
    │
    └── frontend/                  # React TypeScript frontend
        ├── src/
        │   ├── pages/            # Page components
        │   │   ├── LoginPage.tsx
        │   │   └── ExpensesPage.tsx
        │   ├── components/       # Reusable components
        │   ├── services/         # API client
        │   ├── types/            # TypeScript types
        │   └── context/          # React context providers
        ├── package.json
        └── vite.config.ts
    ```

3. **Key technologies in use:**
    - **C# / .NET 8** - Backend programming language and framework
    - **ASP.NET Core Web API** - RESTful API framework
    - **React 18** - Frontend UI library
    - **TypeScript** - Type-safe JavaScript
    - **Vite** - Fast build tool and dev server
    - **Tailwind CSS** - Utility-first CSS framework

## Verifying Your Setup

Let's make sure everything is working correctly:

1. **Check that the backend builds:**

    ```bash
    cd budgetwise-app/backend
    dotnet build
    ```

2. **Check that the frontend builds:**

    ```bash
    cd budgetwise-app/frontend
    npm run build
    ```

3. **Verify GitHub Copilot is active:**
    - Open any `.cs` file in the `budgetwise-app/backend/` directory
    - Start typing a comment like `// Function to calculate`
    - You should see Copilot suggestions appear (ghost text in gray)

## Summary

In this lab, you successfully:

-   ✅ Set up your development environment
-   ✅ Installed and configured GitHub Copilot
-   ✅ Explored the BudgetWise application
-   ✅ Verified your setup is working correctly

You're now ready to dive into using GitHub Copilot to explore and enhance the BudgetWise application!

### Coming up next...

In **Lab 2 - Exploring the Codebase**, you'll:

-   Master advanced Copilot Chat techniques for code comprehension
-   Explore .NET and React application architecture with AI assistance
-   Learn to ask effective questions about complex codebases
-   Use Copilot to generate comprehensive documentation

### Useful URLs

-   Frontend: http://localhost:5173
-   Backend API: http://localhost:5000
-   Swagger UI: http://localhost:5000/swagger

---

## Additional Resources

-   [BudgetWise Application README](../budgetwise-app/README.md)
-   [GitHub Copilot Documentation](https://docs.github.com/en/copilot)
-   [Workshop Glossary](../docs/Glossary.md)
-   [.NET Documentation](https://docs.microsoft.com/dotnet/)
-   [React Documentation](https://react.dev/)

---
