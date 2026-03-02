---
description: 'Generate React component with TypeScript and Tailwind CSS'
agent: 'agent'
---

# Generate React Component

Create a new React component using TypeScript and Tailwind CSS for the BudgetWise frontend.

Component name: ${input:name:ExpenseCard}
Purpose: ${input:purpose:Display expense information}
Location: ${input:location:src/components}

## Requirements:

### TypeScript
- Use TypeScript with proper type definitions
- Define interface for component props
- Use type-safe event handlers
- Avoid using `any` type

### React Best Practices
- Use functional components with hooks
- Use proper prop destructuring
- Include proper dependency arrays in hooks
- Memoize expensive computations with `useMemo`
- Memoize callbacks with `useCallback` when needed

### Styling with Tailwind CSS
- Use Tailwind utility classes for all styling
- Follow mobile-first responsive design
- Include dark mode support with `dark:` prefix
- Use semantic color classes (e.g., `text-gray-900`, `bg-white`)
- Maintain consistent spacing with Tailwind spacing scale

### Accessibility
- Include proper ARIA labels
- Use semantic HTML elements
- Ensure keyboard navigation support
- Add proper alt text for images
- Use proper heading hierarchy

### Code Organization
- Export component as named export
- Place interfaces before component definition
- Use clear, descriptive names
- Add JSDoc comments for complex logic

## Example Structure:

```tsx
import { useState, useEffect } from 'react';
import { formatCurrency, formatDate } from '../utils/formatters';

/**
 * Props for the ${name} component
 */
interface ${name}Props {
  /** Description of prop */
  propName: string;
  /** Optional callback */
  onAction?: (param: string) => void;
  /** Optional CSS class name */
  className?: string;
}

/**
 * ${purpose}
 */
export function ${name}({ propName, onAction, className = '' }: ${name}Props) {
  const [state, setState] = useState<string>('');

  useEffect(() => {
    // Side effects here
  }, [propName]);

  const handleClick = () => {
    onAction?.(propName);
  };

  return (
    <div 
      className={\`bg-white dark:bg-gray-800 rounded-lg shadow p-4 \${className}\`}
      role="article"
      aria-label="${name}"
    >
      <h3 className="text-lg font-semibold text-gray-900 dark:text-white">
        {propName}
      </h3>
      <button
        onClick={handleClick}
        className="mt-2 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700 
                   focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2
                   transition-colors duration-200"
        aria-label="Perform action"
      >
        Click me
      </button>
    </div>
  );
}
```

## Common Component Patterns

### List Component
```tsx
interface ExpenseListProps {
  expenses: Expense[];
  onExpenseClick?: (id: string) => void;
}

export function ExpenseList({ expenses, onExpenseClick }: ExpenseListProps) {
  if (expenses.length === 0) {
    return (
      <div className="text-center text-gray-500 dark:text-gray-400 py-8">
        No expenses found
      </div>
    );
  }

  return (
    <div className="space-y-4">
      {expenses.map(expense => (
        <ExpenseCard
          key={expense.id}
          expense={expense}
          onClick={() => onExpenseClick?.(expense.id)}
        />
      ))}
    </div>
  );
}
```

### Form Component
```tsx
interface ExpenseFormProps {
  onSubmit: (data: CreateExpenseRequest) => void;
  onCancel: () => void;
}

export function ExpenseForm({ onSubmit, onCancel }: ExpenseFormProps) {
  const [formData, setFormData] = useState<CreateExpenseRequest>({
    description: '',
    amount: 0,
    category: '',
    date: new Date().toISOString(),
  });

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit(formData);
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4">
      <div>
        <label 
          htmlFor="description" 
          className="block text-sm font-medium text-gray-700 dark:text-gray-300"
        >
          Description
        </label>
        <input
          type="text"
          id="description"
          value={formData.description}
          onChange={e => setFormData({ ...formData, description: e.target.value })}
          className="mt-1 block w-full rounded-md border-gray-300 shadow-sm 
                     focus:border-blue-500 focus:ring-blue-500 
                     dark:bg-gray-700 dark:border-gray-600 dark:text-white"
          required
        />
      </div>
      
      <div className="flex gap-2">
        <button
          type="submit"
          className="px-4 py-2 bg-blue-600 text-white rounded-md 
                     hover:bg-blue-700 focus:outline-none focus:ring-2 
                     focus:ring-blue-500 focus:ring-offset-2"
        >
          Save
        </button>
        <button
          type="button"
          onClick={onCancel}
          className="px-4 py-2 bg-gray-300 text-gray-700 rounded-md 
                     hover:bg-gray-400 focus:outline-none focus:ring-2 
                     focus:ring-gray-500 focus:ring-offset-2
                     dark:bg-gray-600 dark:text-gray-200 dark:hover:bg-gray-500"
        >
          Cancel
        </button>
      </div>
    </form>
  );
}
```

### Card Component
```tsx
interface CardProps {
  title: string;
  value: string | number;
  icon?: React.ReactNode;
  trend?: 'up' | 'down';
  trendValue?: string;
  className?: string;
}

export function Card({ title, value, icon, trend, trendValue, className = '' }: CardProps) {
  return (
    <div 
      className={\`bg-white dark:bg-gray-800 rounded-lg shadow p-6 \${className}\`}
    >
      <div className="flex items-center justify-between">
        <div>
          <p className="text-sm font-medium text-gray-600 dark:text-gray-400">
            {title}
          </p>
          <p className="mt-2 text-3xl font-semibold text-gray-900 dark:text-white">
            {value}
          </p>
        </div>
        {icon && (
          <div className="text-blue-600 dark:text-blue-400">
            {icon}
          </div>
        )}
      </div>
      {trend && trendValue && (
        <div className="mt-4 flex items-center">
          <span className={\`text-sm font-medium \${
            trend === 'up' ? 'text-green-600' : 'text-red-600'
          }\`}>
            {trend === 'up' ? '↑' : '↓'} {trendValue}
          </span>
        </div>
      )}
    </div>
  );
}
```

Generate the complete component following these patterns and React/TypeScript best practices.
