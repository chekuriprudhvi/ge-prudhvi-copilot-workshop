# Exercise 5 - Prompt Files

#### Duration: 20 minutes

## 🎯 Learning Objectives

By the end of this exercise, you will:
- Create and use prompt files for consistent, reusable AI interactions
- Understand prompt file structure with YAML headers and variables
- Build efficient workflows using standardized prompts
- Share team knowledge through reusable prompt templates

## 💰 Scenario: Standardizing AI Interactions at BudgetWise

Your team at BudgetWise has noticed that developers often repeat similar complex prompts for common operations. You've decided to create reusable prompt files that capture team knowledge and ensure consistency.

Today, you'll learn how to:
- Create reusable prompts that capture team knowledge
- Use variables to make prompts flexible and adaptable
- Streamline repetitive development tasks
- Standardize how the team interacts with Copilot

## 📝 Step 1: Understanding Prompt Files

Prompt files allow you to create reusable, standardized prompts that maintain consistency across your team and save time on repetitive tasks.

### Step 1.1: Why Prompt Files Matter

**Benefits:**
- **Consistency**: Same prompt structure every time
- **Efficiency**: No need to retype complex prompts
- **Standardization**: Team uses the same approaches
- **Knowledge sharing**: Capture expert prompting techniques

### Step 1.2: Prompt File Structure

Prompt files consist of two main parts:

**Header (YAML):**
```yaml
---
description: 'What this prompt does'
agent: 'ask', 'agent', or the name of a custom agent
model: 'optional-specific-model'
tools: ['optional-specific-tools']
---
```

**Body (Markdown):**
```markdown
Your prompt template here with ${input:variableName:placeholder}
```

**Available Variables:**
- `${workspaceFolder}` - Current workspace path
- `${file}` - Current file path
- `${selection}` - Selected text
- `${input:name:placeholder}` - User input with placeholder

**Context References:**
- `@filename` - Reference specific files
- Specific file paths for precise context

## 📋 Step 2: Explore Existing Prompt Files

Let's examine the prompt files already in the repository to understand best practices.

### Step 2.1: Navigate to Prompt Files

1. **Open the `.github/prompts/` folder**

2. **Review the existing prompt files:**
   - Example prompt files will be available in `.github/prompts/`

3. **Notice the consistent structure:**
   - YAML header with metadata
   - Clear description
   - Appropriate agent mode
   - Template body with variables

### Step 2.2: Use an Existing Prompt File

Try using one of the existing prompts to see how they work.

**Generate Mock Data:**

Use one of the existing prompt files to generate mock data for your application.

<details>
<summary>💡 Example</summary>

```
/generate-mock-data 3
```
</details>

**Generate Component/Class:**

Use a prompt file to generate a new component or class for your application.

<details>
<summary>💡 Example</summary>

```
/generate-component for a [describe component]. Place it in the [folder] folder.
```
</details>

### Observe:
- How the prompt automatically fills in your input
- The consistent structure of the generated output
- How variables are replaced with your values

## 🛠️ Step 3: Create Your Own Prompt File

Let's create a custom prompt file for a common task in the BudgetWise project. You'll create a prompt file that generates a new service class with C#, following the project's conventions.

### Step 3.1: Create the Prompt File

**Method 1: Using Copilot Chat UI**
1. Open GitHub Copilot Chat
2. Click the cogwheel (⚙️) in the top-right corner
3. Select "Prompt Files"
4. Click "New prompt file..."
5. Choose `.github/prompts/` as the location
6. Name it `generate-component.prompt.md`

**Method 2: Create Manually**

Create a new file at `.github/prompts/generate-component.prompt.md`

### Step 3.2: Define Your Prompt Template

<details>
  <summary>💡 Example Prompt</summary>

  ```markdown
  ---
  description: "Generate a new service for BudgetWise"
  agent: "agent"
  ---
    
  Create a new C# service for the BudgetWise application.
    
  Service name: ${input:serviceName:ExampleService}
  Service purpose: ${input:purpose:Describe the purpose}
  Location: budgetwise-app/backend/Services/${input:serviceName:ExampleService}.cs
    
  Requirements:
    
  -   Use C# with proper type definitions
  -   Follow ASP.NET Core best practices
  -   Make it reusable and maintainable
  -   Include proper documentation
  -   Follow the existing patterns in the codebase
    
  The service should be production-ready.
  ```

</details>

### Step 3.3: Test Your Prompt File

1. In Copilot Chat, type `/` to see available prompt files
2. Type `/generate-component`
3. Provide values for the input variables
   - Example: `/generate-component componentName=ExampleComponent`
4. Press Enter
5. Review the generated code

### ✅ Success Criteria
- [ ] Your prompt file appears in the `/` command list
- [ ] Variables are correctly replaced with your input
- [ ] Generated code follows project conventions
- [ ] Component is created in the correct location

## 💡 Step 4: Advanced Prompt File Techniques

### Step 4.1: Using Multiple Variables

Create prompts with multiple input variables for flexibility:

```markdown
---
description: 'Create a feature with tests'
agent: 'agent'
---

Create a new ${input:featureType:component} called ${input:name:MyFeature}.

Add the following functionality:
${input:functionality:Describe the functionality here}

Also create unit tests using the project's testing framework.
```

### Step 4.2: Using Workspace Variables

Reference current file and workspace context:

```markdown
---
description: 'Refactor current file'
agent: 'agent'
---

Refactor the file at ${file} to improve:
- Code readability
- Performance
- Type safety

Current working directory: ${workspaceFolder}
```

### Step 4.3: Using File Context

Reference specific files for context:

```markdown
---
description: 'Create similar component'
agent: 'agent'
---

Create a component similar to the BaseComponent at [src/components/BaseComponent.cs](${workspaceFolder}/src/components/BaseComponent.cs) but for ${input:purpose:new functionality}.

Follow the same patterns and conventions.
```

## 🎯 Step 5: Best Practices for Prompt Files

### Naming Conventions
- Use descriptive names: `generate-component` not `gen-comp`
- Use kebab-case: `create-api-endpoint` not `CreateAPIEndpoint`
- Group related prompts: `test-generate-unit`, `test-generate-integration`

### Structure Guidelines
1. **Clear Description**: Make it obvious what the prompt does
2. **Right Agent Mode**: 
   - Use `ask` for questions
   - Use `agent` for code generation/modification or autonomous multi-file tasks
   - Use `CustomAgentName` for specialized workflows
3. **Meaningful Defaults**: Provide helpful placeholder values
4. **Precise Instructions**: Be specific about requirements
5. **Context References**: Include relevant files with `@` notation

### Collaboration Tips
- Document your prompts with clear descriptions
- Share prompt files through version control
- Review and refine based on team feedback
- Create prompt files for frequently repeated tasks
- Maintain consistency across related prompts

## 🏆 Exercise Wrap-up

Excellent work! You've mastered prompt files:
- ✅ Understood the benefits of prompt files for team productivity
- ✅ Explored existing prompt files in the repository
- ✅ Created your own custom prompt file
- ✅ Learned to use variables and context references
- ✅ Applied best practices for prompt file creation

### Reflection Questions:
1. **What repetitive tasks in your workflow could benefit from prompt files?**
2. **How could prompt files help standardize your team's approach to common tasks?**
3. **What variables would make your prompts more flexible?**
4. **How will you share and maintain prompt files with your team?**

### Key Takeaways:
- Prompt files capture team knowledge and ensure consistency
- Variables make prompts flexible and reusable
- Clear descriptions and proper agent modes improve usability
- Version control enables team collaboration on prompts
- Prompt files multiply productivity across your entire team

## Coming up next...

In the next lab, you'll learn about Custom Agents:
- Create custom agents for specialized development workflows
- Build agents with expert knowledge for specific technologies
- Use agents for autonomous task execution
- Share agents across your organization for consistent practices
