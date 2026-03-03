// User types
export interface User {
  id: number;
  username: string;
  email: string;
  firstName: string;
  lastName: string;
}

export interface LoginRequest {
  username: string;
  password: string;
}

export interface LoginResponse {
  success: boolean;
  message?: string;
  user?: User;
  token?: string;
}

// Expense types
export interface Expense {
  id: number;
  description: string;
  amount: number;
  date: string;
  category: string;
  notes?: string;
  isRecurring: boolean;
}

export interface ExpenseFormData {
  description: string;
  amount: number;
  date: string;
  category: string;
  notes?: string;
  isRecurring: boolean;
}

// Category types
export interface Category {
  name: string;
  color: string;
}

// Summary types
export interface ExpenseSummary {
  totalSpending: number;
  expenseCount: number;
  spendingByCategory: Record<string, number>;
  categories: Category[];
}

// Profile types
export interface UserProfile {
  id: number;
  username: string;
  email: string;
  firstName: string;
  lastName: string;
  bio: string;
  location: string;
  memberSince: string;
  avatarInitials: string;
}

// TODO: Lab 3 - Add Budget types
// export interface Budget {
//   id: number;
//   name: string;
//   amount: number;
//   categoryId?: number;
//   startDate: string;
//   endDate: string;
//   userId: number;
//   createdAt: string;
// }

// TODO: Lab 4 - Add Chart data types
// export interface SpendingDataPoint {
//   date: string;
//   amount: number;
//   category?: string;
// }

// TODO: Lab 6 - Add Rule types
// export interface ExpenseRule {
//   name: string;
//   description: string;
//   isEnabled: boolean;
//   threshold?: number;
// }
//
// export interface ExpenseRuleResult {
//   hasWarning: boolean;
//   message?: string;
//   ruleName?: string;
// }
