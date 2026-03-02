import type { Expense, ExpenseSummary, LoginRequest, LoginResponse, Category } from '../types';

const API_BASE_URL = 'http://localhost:5000/api';

/**
 * API service for communicating with the BudgetWise backend
 */
export const api = {
  // Auth endpoints
  async login(credentials: LoginRequest): Promise<LoginResponse> {
    const response = await fetch(`${API_BASE_URL}/auth/login`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(credentials),
    });
    return response.json();
  },

  async getCurrentUser() {
    const response = await fetch(`${API_BASE_URL}/auth/me`);
    return response.json();
  },

  async logout() {
    const response = await fetch(`${API_BASE_URL}/auth/logout`, {
      method: 'POST',
    });
    return response.json();
  },

  // Expense endpoints
  async getExpenses(): Promise<Expense[]> {
    const response = await fetch(`${API_BASE_URL}/expenses`);
    return response.json();
  },

  async getExpenseById(id: number): Promise<Expense> {
    const response = await fetch(`${API_BASE_URL}/expenses/${id}`);
    return response.json();
  },

  async createExpense(expense: Omit<Expense, 'id'>): Promise<Expense> {
    const response = await fetch(`${API_BASE_URL}/expenses`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(expense),
    });
    return response.json();
  },

  // TODO: Lab 3 - Implement updateExpense
  // async updateExpense(id: number, expense: Expense): Promise<Expense> {
  //   const response = await fetch(`${API_BASE_URL}/expenses/${id}`, {
  //     method: 'PUT',
  //     headers: { 'Content-Type': 'application/json' },
  //     body: JSON.stringify(expense),
  //   });
  //   return response.json();
  // },

  // TODO: Lab 3 - Implement deleteExpense
  // async deleteExpense(id: number): Promise<void> {
  //   await fetch(`${API_BASE_URL}/expenses/${id}`, {
  //     method: 'DELETE',
  //   });
  // },

  async getExpensesByCategory(category: string): Promise<Expense[]> {
    const response = await fetch(`${API_BASE_URL}/expenses/category/${encodeURIComponent(category)}`);
    return response.json();
  },

  async getExpenseSummary(): Promise<ExpenseSummary> {
    const response = await fetch(`${API_BASE_URL}/expenses/summary`);
    return response.json();
  },

  // Category endpoints
  async getCategories(): Promise<Category[]> {
    const response = await fetch(`${API_BASE_URL}/categories`);
    return response.json();
  },

  // TODO: Lab 4 - Add chart data endpoints
  // async getSpendingOverTime(startDate: string, endDate: string, groupBy: string = 'day') {
  //   const params = new URLSearchParams({ startDate, endDate, groupBy });
  //   const response = await fetch(`${API_BASE_URL}/expenses/spending-over-time?${params}`);
  //   return response.json();
  // },

  // TODO: Lab 5 - Add export endpoints
  // async exportToCsv(startDate?: string, endDate?: string): Promise<Blob> {
  //   const params = new URLSearchParams();
  //   if (startDate) params.append('startDate', startDate);
  //   if (endDate) params.append('endDate', endDate);
  //   const response = await fetch(`${API_BASE_URL}/expenses/export/csv?${params}`);
  //   return response.blob();
  // },
  //
  // async exportToPdf(startDate?: string, endDate?: string): Promise<Blob> {
  //   const params = new URLSearchParams();
  //   if (startDate) params.append('startDate', startDate);
  //   if (endDate) params.append('endDate', endDate);
  //   const response = await fetch(`${API_BASE_URL}/expenses/export/pdf?${params}`);
  //   return response.blob();
  // },

  // Health check
  async checkHealth() {
    const response = await fetch(`${API_BASE_URL}/health`);
    return response.json();
  },
};
