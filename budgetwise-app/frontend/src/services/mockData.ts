import type { Expense, Category, ExpenseSummary } from '../types';

/**
 * Mock data for development when the backend is not available
 * This allows the frontend to be developed and tested independently
 */

export const mockCategories: Category[] = [
  { name: 'Groceries', color: '#22c55e' },
  { name: 'Housing', color: '#3b82f6' },
  { name: 'Utilities', color: '#f59e0b' },
  { name: 'Entertainment', color: '#8b5cf6' },
  { name: 'Transportation', color: '#06b6d4' },
  { name: 'Food & Dining', color: '#ec4899' },
  { name: 'Health & Fitness', color: '#14b8a6' },
  { name: 'Shopping', color: '#f97316' },
  { name: 'Insurance', color: '#64748b' },
  { name: 'Education', color: '#6366f1' },
  { name: 'Personal Care', color: '#d946ef' },
  { name: 'Travel', color: '#0ea5e9' },
  { name: 'Subscriptions', color: '#a855f7' },
  { name: 'Other', color: '#78716c' },
];

export const mockExpenses: Expense[] = [
  {
    id: 1,
    description: 'Grocery shopping at Whole Foods',
    amount: 127.45,
    date: new Date(Date.now() - 1 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Groceries',
    notes: 'Weekly grocery run',
    isRecurring: false,
  },
  {
    id: 2,
    description: 'Monthly rent payment',
    amount: 1850.0,
    date: new Date(Date.now() - 5 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Housing',
    notes: 'Apartment rent for December',
    isRecurring: true,
  },
  {
    id: 3,
    description: 'Electric bill',
    amount: 95.3,
    date: new Date(Date.now() - 3 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Utilities',
    notes: undefined,
    isRecurring: true,
  },
  {
    id: 4,
    description: 'Netflix subscription',
    amount: 15.99,
    date: new Date(Date.now() - 10 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Entertainment',
    notes: 'Premium plan',
    isRecurring: true,
  },
  {
    id: 5,
    description: 'Gas station fill-up',
    amount: 52.8,
    date: new Date(Date.now() - 2 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Transportation',
    notes: 'Shell gas station',
    isRecurring: false,
  },
  {
    id: 6,
    description: 'Coffee at Starbucks',
    amount: 6.75,
    date: new Date().toISOString(),
    category: 'Food & Dining',
    notes: 'Morning latte',
    isRecurring: false,
  },
  {
    id: 7,
    description: 'Gym membership',
    amount: 49.99,
    date: new Date(Date.now() - 15 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Health & Fitness',
    notes: 'Monthly membership fee',
    isRecurring: true,
  },
  {
    id: 8,
    description: 'Amazon purchase - Electronics',
    amount: 189.99,
    date: new Date(Date.now() - 7 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Shopping',
    notes: 'Wireless headphones',
    isRecurring: false,
  },
  {
    id: 9,
    description: 'Restaurant dinner',
    amount: 78.5,
    date: new Date(Date.now() - 4 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Food & Dining',
    notes: 'Birthday dinner with friends',
    isRecurring: false,
  },
  {
    id: 10,
    description: 'Car insurance premium',
    amount: 145.0,
    date: new Date(Date.now() - 20 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Insurance',
    notes: 'Quarterly payment',
    isRecurring: true,
  },
  {
    id: 11,
    description: 'Spotify Premium',
    amount: 10.99,
    date: new Date(Date.now() - 8 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Entertainment',
    notes: 'Music streaming service',
    isRecurring: true,
  },
  {
    id: 12,
    description: 'Pharmacy - Medications',
    amount: 35.5,
    date: new Date(Date.now() - 6 * 24 * 60 * 60 * 1000).toISOString(),
    category: 'Health & Fitness',
    notes: 'Monthly prescription',
    isRecurring: true,
  },
];

export function getMockSummary(): ExpenseSummary {
  const totalSpending = mockExpenses.reduce((sum, exp) => sum + exp.amount, 0);
  const spendingByCategory = mockExpenses.reduce((acc, exp) => {
    acc[exp.category] = (acc[exp.category] || 0) + exp.amount;
    return acc;
  }, {} as Record<string, number>);

  return {
    totalSpending,
    expenseCount: mockExpenses.length,
    spendingByCategory,
    categories: mockCategories,
  };
}

export const mockUser = {
  id: 1,
  username: 'demo',
  email: 'demo@budgetwise.com',
  firstName: 'Alex',
  lastName: 'Johnson',
};
