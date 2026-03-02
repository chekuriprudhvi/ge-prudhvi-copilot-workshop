# Exercise 3 - Code Editing and Generation with GitHub Copilot

#### Duration: 40 minutes

## 🎯 Learning Objectives

By the end of this exercise, you will:
- Use GitHub Copilot's Plan mode to preview changes before execution
- Master GitHub Copilot's Agent mode for code generation and modifications (both targeted and multi-file)
- Understand when to use Ask mode vs. Plan mode vs. Agent mode in the IDE
- Generate new features and components with context-aware AI assistance
- Review and refine AI-generated code effectively
- Learn best practices for iterative AI-assisted development

## 💰 Scenario: Enhancing BudgetWise Features

Your manager at BudgetWise has requested several new features that will require changes across multiple files. You've been tasked with implementing these enhancements efficiently while maintaining the high quality standards of the codebase.

Your task today is to use GitHub Copilot's Plan and Agent modes to:
- Preview changes with Plan mode before execution
- Make targeted, deliberate changes with Agent mode
- Implement multi-file features with Agent mode assistance
- Create new components and integrate them into the application
- Make context-aware changes across the codebase

## 💡 Understanding GitHub Copilot Chat Modes

Before we dive into code generation, let's understand the different ways you can interact with GitHub Copilot in VS Code. GitHub Copilot Chat offers multiple modes, each optimized for different types of tasks:

| Mode | Trigger | Best For | Scope |
|------|---------|----------|-------|
| **Ask Mode** | Copilot Chat, select "Ask" | Understanding code, getting explanations, learning concepts | Read-only, no changes |
| **Plan Mode** | Copilot Chat, select "Plan" | Previewing changes before execution, understanding impact before committing | Shows detailed plan without making changes |
| **Agent Mode** | Copilot Chat, select "Agent" | Targeted changes, exploratory tasks, architectural planning, complex problem-solving | Single files to workspace-wide, autonomous |

> **Note**: Edit mode has been deprecated. Its functionality for targeted code changes is now handled by Agent mode, which can perform both targeted single-file edits and complex multi-file operations.

> **You learned Ask mode in Lab 2** where you explored the codebase. Now we'll focus on **Plan Mode** and **Agent Mode** for making code changes.

### 🎯 Understanding IDE Code Generation Modes

**When to use each mode:**

- **Ask Mode**: Use when you need to understand code first, want suggestions before implementation, or are exploring different approaches.

- **Plan Mode**: Use when you want to preview what changes Copilot would make before executing them. Plan mode generates a detailed plan which can include showing: files to be modified, changes to be made, and the reasoning behind decisions, without actually applying any changes. Great for understanding impact and validating approach before committing.

- **Agent Mode**: Use for all code changes, whether targeted or exploratory. Agent mode can make deliberate, specific modifications to a single file or autonomously explore your codebase and implement complex multi-file features. It handles everything from quick bug fixes to architectural refactoring.

> **Note**: In this lab, you'll practice with **Plan mode** and **Agent mode** to understand when to use each. **IDE Agent mode** (this lab) works interactively within VS Code, different from **Coding Agent** (Lab 9) which works autonomously on GitHub issues.

## 📝 Step 1: Using Agent Mode for Targeted Code Changes

Agent mode is versatile - it can handle both exploratory multi-file work and targeted single-file changes. Let's start with Agent mode to make focused improvements to existing code, demonstrating that it works well for precise, scoped modifications.

### Exercise: Quick Refactoring with Agent Mode

Let's use Agent mode for a focused improvement to existing code.

### Instructions:

1. **Open the file** `budgetwise-app/backend/Services/ExpenseService.cs`

2. **Select the GetAllExpenses method** (around lines 14-29)

3. **Open Copilot Chat in Agent mode**
   - Click the chat icon in the sidebar (or press `Ctrl+Alt+I` / `Cmd+Ctrl+I`)
   - Ensure you're in **Agent mode** (select "Agent" from the mode selector at the bottom of the chat window)

4. **Request a targeted improvement:**
   
   Create a prompt that asks Copilot to refactor the selected code. Your prompt should request specific improvements relevant to your tech stack. Reference the file explicitly to keep changes targeted.

   <details>
   <summary>💡 Example Prompt</summary>

   ```
   Refactor the GetAllExpenses method in ExpenseService.cs to add proper error handling, add XML documentation comments, and improve code readability. Only modify this specific method.
   ```
   </details>

5. **Review the changes before accepting:**
   - Agent mode shows you a diff of what will change
   - You can see exactly what code is being added/removed
   - Accept if it looks good, or refine your prompt

6. **Keep and test:**
   - Click "Keep" to accept the changes
   - Save the file
   - Build the project to verify it still compiles: `dotnet build`

### 💡 Agent Mode Best Practices for Targeted Changes:

- **Be explicit about scope**: Specify exactly which files and methods should be modified
- **Reference the file**: Include the filename in your prompt to keep changes focused
- **Use specific language**: Say "only modify this method" or "limit changes to this file"
- **Review diffs carefully**: Agent mode shows you exactly what will change
- **Control with clear boundaries**: Agent mode respects explicit constraints in your prompt

## 📋 Step 2: Using Plan Mode to Preview Changes Before Execution

Now that you've made targeted changes with Agent mode, let's explore Plan mode. Plan mode lets you see exactly what Copilot would do before any code is modified. This preview is perfect for understanding impact and validating your approach.

**How Plan Mode Works:**
1. You describe what you want to accomplish
2. Copilot analyzes your codebase and creates a detailed plan
3. The plan shows:
   - Which files will be modified or created
   - What specific changes will be made to each file
   - The reasoning behind the changes
   - Dependencies and impacts
4. You review the plan without any code being changed
5. You can then execute the plan, modify your request, or try a different approach

**Benefits:**
- **Risk reduction**: See the impact before changes are made
- **Learning opportunity**: Understand AI's decision-making process
- **Better prompts**: Refine your request based on the preview
- **Confidence**: Proceed with changes knowing what will happen

**When to Use Plan Mode:**
- Before making significant refactoring changes
- When working with unfamiliar code sections
- To validate your approach before implementation
- When you want to understand AI's reasoning
- Before changes that might affect multiple files

### Exercise: Preview a Component Addition with Plan Mode

Let's use Plan mode to preview adding a new component to the application. This will show you what files Copilot would create and modify, without actually making any changes yet.

### Instructions:

1. **Open GitHub Copilot Chat:**
   - Click the chat icon in the sidebar (or press `Ctrl+Alt+I` / `Cmd+Ctrl+I`)
   - Ensure you're in **Plan mode** (select "Plan" from the mode selector at the top)

2. **Provide context by opening related files:**
   - Open `budgetwise-app/frontend/src/App.tsx` to show the main layout where the footer will be integrated
   - Open `budgetwise-app/frontend/src/pages/ExpensesPage.tsx` as an example of existing component style
   - Having these files open helps Plan mode understand your project patterns

3. **Request a plan for adding a new component:**
   
   Create a prompt that asks Plan mode to show what changes would be needed to add a new component. Your prompt should specify:
   - Creating a new component file
   - Following the existing design system
   - Integrating it into the layout
   
   <details>
   <summary>💡 Example Prompt</summary>

   ```
   Create a footer component for this application and integrate it into the main layout.
   
   Requirements:
   - Create a new Footer.tsx component (create a components folder if needed)
   - Include BudgetWise branding/logo text
   - Add copyright information with current year
   - Include links to About, Privacy, and Terms pages
   - Style using Tailwind CSS following the existing design system
   - Add the component to App.tsx so it appears on all pages
   
   Follow the patterns used in existing pages like ExpensesPage.tsx.
   ```
   </details>

4. **Analyze the plan:**
   - Review what files Plan mode wants to create/modify
   - Check if the proposed changes align with your expectations
   - Look at the imports it plans to add
   - Verify the styling approach matches existing components
   - Read the reasoning to understand AI's decision-making

5. **Note your observations:**
   - Does the plan look good?
   - Are there any files you didn't expect to be modified?
   - Is the approach what you would have taken?
   - Do you see any potential issues?

### 💡 Plan Mode Best Practices:

- **Use before significant changes**: Always preview complex refactoring or multi-file features
- **Validate AI's approach**: Check if the plan matches your mental model
- **Refine your prompt**: If the plan isn't right, adjust your request and try again
- **Compare alternatives**: Try different prompts to see different approaches
- **Learn from the reasoning**: Understand why AI makes certain decisions

## 🤖 Step 3: Using Agent Mode to Execute the Plan

Now that you've previewed the component changes with Plan mode, let's use Agent mode to actually implement it. You'll see how Plan mode helps you understand what will happen, while Agent mode executes the changes.

### Exercise: Execute the Component with Agent Mode

We'll use the same requirements from Step 2, but this time Agent mode will actually create and modify files.

### Instructions:

1. **Switch to Agent mode:**
   - In the same Copilot Chat window, change from "Plan" to "Agent" mode

2. **Provide the same context:**
   - Ensure `budgetwise-app/frontend/src/App.tsx` is open (the layout file)
   - Ensure `budgetwise-app/frontend/src/pages/ExpensesPage.tsx` is open (for component pattern reference)
   - Agent mode will use these for context just like Plan mode did

3. **Have Agent mode implement the plan:**
   - Since Plan mode gave us all the steps to implement, we just need to tell Copilot to implement it!
   - Tell Copilot: `Implement the plan`

5. **Watch Agent mode work:**
   - Agent mode will create the new component file
   - It will modify the layout file to import and use the component
   - Changes appear in your editor in real-time
   - You can see the progress in the chat window

6. **Compare to the Plan mode preview:**
   - Are the actual changes similar to what Plan mode predicted?
   - Did Agent mode create the same files?
   - Are the code changes what you expected from the plan?
   - Note any differences between the plan and the execution

7. **Review the generated code:**
   - Check the new Footer.tsx component file
   - Review the changes to App.tsx
   - Verify the styling matches existing components
   - Ensure proper TypeScript types are used
   - Check that imports are correct

8. **Test your changes:**
   - `Keep` all of the changes and save all modified files
   - Check the browser at [http://localhost:5173](http://localhost:5173)
   - Verify your new component appears correctly
   - If any styling or features didn't work, iterate on the prompt with Agent mode

### 💡 Pro Tips for Agent Mode:

- **Be specific about file locations**: Specify exact paths where new files should be created
- **Reference existing patterns**: Point Agent mode to similar components to follow
- **Review before accepting**: Always check Agent mode's output before accepting it
- **Iterate if needed**: You can refine your prompt and try again if the plan isn't quite right. You don't have to opt to `Keep` anything to iterate. Simply type a follow-up prompt to Copilot and it will continue working.

### 🔍 Targeted vs Exploratory Agent Mode Prompts:

Agent mode is versatile and can handle both targeted and exploratory tasks. The difference is in how you frame your prompt.

**Example Scenario**: Adding error handling

**Targeted approach** (when you know exactly what to change):
```
Add try-catch error handling to these specific files:
- budgetwise-app/backend/Services/ExpenseService.cs (in the GetAllExpenses method)
- budgetwise-app/backend/Controllers/ExpenseController.cs (in the Get action)
- budgetwise-app/backend/Services/BudgetService.cs (in the data export)

Only modify these files. Use consistent error messages and logging.
```
*Result: Targeted, deliberate changes to the 3 files you specified*

**Exploratory approach** (when you want AI to discover what needs changing):
```
Analyze the application and add appropriate error handling wherever needed. 
Use your judgment to determine which components need error boundaries, 
which functions need try-catch blocks, and how to handle errors gracefully.
```
*Result: AI autonomously explores, plans, and implements error handling across multiple files*

### ⚠️ Key Difference:

**Targeted prompts**: You tell Copilot what to change and where (explicit file/method references)  
**Exploratory prompts**: Copilot explores, decides what to change, and where to make those changes

## 🎯 Step 4: Using Agent Mode for Multi-File Feature Implementation

Now let's use Agent mode for a more complex task that involves creating a new feature across multiple files.

### Scenario:

The application needs a "Budget Overview" widget on the expenses page that shows:
- Total budget amount
- Amount spent
- Remaining budget
- Progress bar visualization

### Instructions:

1. **Prepare the context:**
   - Open `budgetwise-app/frontend/src/pages/ExpensesPage.tsx` (the page where the feature will be added)
   - Open `budgetwise-app/frontend/src/types/index.ts` (to see the data structure)
   - Open `budgetwise-app/frontend/src/App.tsx` (for component pattern reference)

2. **Prompt Agent mode with the complete requirement:**

   Create a comprehensive prompt that covers the core requirements for adding a new feature. Your prompt should specify:
   - Creating a new component/class
   - Modifying data types if needed
   - Updating mock/sample data
   - Integrating into the appropriate page with proper styling and responsiveness
   
   **Hint**: Using markdown format to create lists of requirements is a very effective method when working with AI
   
   <details>
   <summary>💡 Example Prompt</summary>

   ```
   Create a Budget Overview widget for the expenses page.
   
   Tasks:
   1. Create a new BudgetOverview.tsx component (create a components folder if needed)
   2. The component should display:
      - Total monthly budget ($3000 for demo)
      - Amount spent (calculate from expenses)
      - Remaining budget
      - A visual progress bar showing budget usage
   3. Add TypeScript types in the types file if needed
   4. Import and add BudgetOverview to the ExpensesPage above the expenses list
   5. Style using Tailwind CSS with the existing design patterns
   6. Support dark mode
   7. Make it responsive (different layouts for mobile/desktop)
   
   Follow patterns from existing components.
   ```
   </details>

4. **Monitor the implementation:**
   - Watch as Agent mode creates the component
   - See it update the data structure and sample data
   - Observe it integrate everything into the page
   - Check that it follows existing patterns

5. **Review and test:**
   - Check each modified/created file
   - Verify TypeScript types are consistent
   - Test the homepage at [http://localhost:5173](http://localhost:5173)
   - Confirm the featured section appears and looks good
   - Test responsiveness by resizing the browser

### 🔍 Understanding Agent Mode's Workflow:

When you accept the plan, Agent mode:
1. **Analyzes** your entire workspace and relevant files
2. **Plans** the sequence of changes needed
3. **Creates** new files with appropriate content
4. **Modifies** existing files to integrate the new feature
5. **Validates** that changes follow project patterns
6. **Applies** all changes atomically

## 🔄 Step 5: Iterating and Refining with Agent Mode

One of Agent mode's strengths is the ability to iterate on existing code. Let's practice this by enhancing an existing component or the one you created in Step 4.

### Scenario:

You want to add animations and improve the user experience for one of the components. This demonstrates iterative refinement with Agent mode.

### Instructions:

1. **Choose a component to enhance:**
   - Open the BudgetOverview.tsx component you just created in Step 4
   - Ensure the file is included as context (hint: `#BudgetOverview.tsx`)
   - You'll want to use the same chat session you used in Step 4

2. **Continue the conversation in Agent mode:**
   
   Agent mode remembers your previous conversation, so you can build on it. Create a prompt to enhance the component you created in Step 4:

   <details>
   <summary>💡 Example Prompt</summary>

   ```
   Enhance the BudgetOverview component we just created:
   
   Improvements:
   1. Add smooth entrance animations using CSS transitions
   2. Add color coding: green when under 50%, yellow 50-80%, red over 80%
   3. Include a warning icon when over budget
   4. Add hover effects on the progress bar
   5. Show spending trend (up/down arrow) compared to last month
   
   Keep the existing styling patterns.
   ```
   </details>

4. **Review agent mode's changes:**
   - Agent mode will show what files it modifies as it works
   - Verify that it updates the correct file
   - You should see new imports for animation libraries if applicable
   - Accept the changes

5. **Test the improvements:**
   - Refresh the browser and observe the animations
   - Hover over items to see the effects
   - Resize the browser to see responsive behavior

6. **Request additional refinements if needed:**
   
   You can continue the conversation:
   ```
   Make the animation timing slower and more elegant
   ```
   
   Or:
   ```
   Add a subtle background pattern to the section
   ```

   OR:
   Have Copilot refine the changes to what you think will look best. There are no wrong answers!

### 💡 Benefits of Iterating with Agent Mode:

- **Context preservation**: Agent mode remembers what it just built
- **Incremental improvements**: Make changes step-by-step rather than all at once
- **Learning opportunity**: See how to progressively enhance features
- **Safe experimentation**: Easy to ask for changes and see results immediately

### 🔍 Providing Effective Feedback to Agent Mode:

When iterating, be specific about what you want changed:

**Good iteration prompts:**
- ✅ "Make the animation duration 0.5 seconds instead of the current timing"
- ✅ "Change the hover scale from 1.05 to 1.02 for a more subtle effect"
- ✅ "Add error handling for when the data array is empty"

**Less effective prompts:**
- ❌ "Make it better"
- ❌ "Fix the animations"
- ❌ "Improve performance"

### 🎯 Practice Exercise:

Try one more iteration on your own:
1. Ask Agent mode to add captions that appear on hover
2. Request that clicking an item navigates to a detail view
3. Add a smooth transition between items on mobile

### ⚠️ When to Stop Iterating:

Watch for signs that you should start a fresh conversation:
- The conversation history becomes very long
- Agent mode starts making unrelated changes
- You're changing direction significantly from the original task

**Tip**: Start a new Agent mode conversation for unrelated features

## 🎓 Step 6: Best Practices for IDE AI-Assisted Development

Let's review what makes for effective AI-assisted development in the IDE:

### ✅ Do's for Agent Mode:

1. **Use for Both Targeted and Exploratory Work**: Agent mode handles both
   - ✅ Targeted: "Refactor the GetAllExpenses method in ExpenseService.cs"
   - ✅ Exploratory: "Add comprehensive error handling wherever appropriate"

2. **Be Explicit When You Want Targeted Changes**: Specify files and methods
   - ✅ "Only modify this file"
   - ✅ "Limit changes to the authentication module"
   - Reference specific file paths to keep scope focused

3. **Let AI Explore When Appropriate**: Give high-level goals for exploratory work
   - "Add comprehensive error handling to the application where appropriate"
   - "Refactor the data layer for better performance"

4. **Provide Context**: Open relevant files to guide discovery
   - Open similar components for style patterns
   - Reference existing patterns: "Follow patterns in @ExampleComponent"

5. **Review Before Accepting**: Always check what Agent mode intends to do
   - Verify all files to be modified are correct
   - Ensure no unintended changes
   - Confirm the approach makes sense

6. **Iterate Conversationally**: Build on previous context
   - "Now add animations to the component we just created"
   - "Enhance the Featured section with hover effects"

### ❌ Universal Don'ts:

1. **Don't skip review**: Always understand generated code before using it
2. **Don't ignore errors**: If your language/compiler complains, investigate and fix
3. **Don't forget testing**: Test all AI-generated code in the browser
4. **Don't lose context**: If conversations get long, start fresh
5. **Don't over-rely**: AI is a powerful assistant, **not a replacement for thinking**

### 🎯 Mode Selection Quick Guide:

| Scenario | Use This Mode | Why |
|----------|--------------|-----|
| Explore codebase and decide what to change | **Agent** | Autonomous discovery and planning |
| Complex problem where solution isn't clear | **Agent** | AI determines best approach |
| Architectural planning and implementation | **Agent** | Workspace-wide context and decisions |
| Refactor specific files you identify | **Agent** (targeted prompt) | Specify files in prompt for focused changes |
| Fix bug in known locations | **Agent** (targeted prompt) | Reference specific files and methods |
| Add feature to specific components | **Agent** (targeted prompt) | Be explicit about scope in prompt |
| Preview changes before executing | **Plan** | See impact without modifying code |
| Validate approach before committing | **Plan** | Review plan and reasoning first |
| Understand code or get suggestions | **Ask** | Read-only exploration |

## 🏆 Exercise Wrap-up

Excellent work! You've mastered GitHub Copilot's IDE modes for code generation:
- ✅ Used Agent mode for targeted, surgical code improvements
- ✅ Used Plan mode to preview changes before execution
- ✅ Understood the value of validating AI's approach before committing
- ✅ Used Agent mode to create multi-file features with full integration
- ✅ Implemented complex functionality across components, data, and pages
- ✅ Iterated on AI-generated code to refine and enhance features
- ✅ Learned when to use each mode for maximum effectiveness

### Reflection Questions:
1. **How does Plan mode change your confidence when making large changes?**
2. **When would you use Plan mode before Agent mode?**
3. **How does Agent mode's versatility (targeted and exploratory) change your workflow?**
4. **How do you control Agent mode's scope when you want targeted changes?**
5. **What surprised you about Agent mode's understanding of your codebase?**
6. **How might you use iterative prompting to build complex features?**
7. **What strategies will you use to provide better context to Copilot?**

### Key Takeaways:
- **Agent mode is versatile**: It handles both targeted single-file changes and complex multi-file features
- **Control scope with explicit prompts**: Specify files and methods when you want targeted changes
- **Plan mode is essential** for previewing changes and validating approaches before execution
- Use **Plan mode before Agent mode** for complex changes to build confidence
- Context is critical: open related files and reference existing patterns
- Iterative development with AI works just like with human developers
- Always review, test, and understand what AI generates
- Clear requirements and specific prompts yield better results

### 🎯 Real-World Applications:

**Plan Mode Use Cases:**
- Previewing refactoring before execution
- Validating approach for complex features
- Understanding impact of multi-file changes
- Learning AI's reasoning and decision-making

**Agent Mode Use Cases (Exploratory):**
- Building new features from scratch
- Adding components with full integration
- Implementing requirements that touch multiple files
- Refactoring that affects architecture

**Agent Mode Use Cases (Targeted):**
- Quick bug fixes in specific files
- Performance optimizations in specific functions
- Adding error handling to identified code sections
- Refining algorithms or logic in specific methods

## Coming up next...

In the next lab, you'll explore engineering best practices with GitHub Copilot:
- Understand how Copilot makes decisions and inspect its reasoning process
- Configure personal instructions and custom settings for your workflow
- Learn to manage model usage and costs effectively
- Master the hierarchy of custom instructions for optimal AI assistance
