import { useAuth } from '../context/AuthContext';
import { mockProfile, mockExpenses, getMockSummary } from '../services/mockData';
import {
  DollarSign,
  MapPin,
  Calendar,
  TrendingUp,
  LogOut,
  ArrowLeft,
  Mail,
  Repeat,
} from 'lucide-react';
import { useNavigate } from 'react-router-dom';

const DEFAULT_CATEGORY_COLOR = '#78716c';

export function ProfilePage() {
  const { logout } = useAuth();
  const navigate = useNavigate();
  const summary = getMockSummary();
  const recentExpenses = mockExpenses.slice(0, 5);

  const handleLogout = () => {
    logout();
    navigate('/');
  };

  const formatCurrency = (amount: number) => {
    return new Intl.NumberFormat('en-US', {
      style: 'currency',
      currency: 'USD',
    }).format(amount);
  };

  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString('en-US', {
      month: 'short',
      day: 'numeric',
      year: 'numeric',
    });
  };

  const formatMemberSince = (dateString: string) => {
    return new Date(dateString).toLocaleDateString('en-US', {
      month: 'long',
      year: 'numeric',
    });
  };

  return (
    <div className="min-h-screen bg-gray-50 dark:bg-gray-900">
      {/* Header */}
      <header className="bg-white dark:bg-gray-800 shadow-sm">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-4">
          <div className="flex items-center justify-between">
            <div className="flex items-center gap-3">
              <div className="w-10 h-10 bg-blue-600 rounded-full flex items-center justify-center">
                <DollarSign className="w-5 h-5 text-white" />
              </div>
              <div>
                <h1 className="text-xl font-bold text-gray-900 dark:text-white">
                  BudgetWise
                </h1>
                <p className="text-sm text-gray-500 dark:text-gray-400">
                  Your Profile
                </p>
              </div>
            </div>
            <div className="flex items-center gap-4">
              <button
                onClick={() => navigate('/expenses')}
                className="flex items-center gap-2 px-3 py-2 text-gray-600 dark:text-gray-300 hover:bg-gray-100 dark:hover:bg-gray-700 rounded-lg transition-colors"
              >
                <ArrowLeft className="w-5 h-5" />
                <span className="hidden sm:inline">Back to Expenses</span>
              </button>
              <button
                onClick={handleLogout}
                className="flex items-center gap-2 px-3 py-2 text-gray-600 dark:text-gray-300 hover:bg-gray-100 dark:hover:bg-gray-700 rounded-lg transition-colors"
              >
                <LogOut className="w-5 h-5" />
                <span className="hidden sm:inline">Logout</span>
              </button>
            </div>
          </div>
        </div>
      </header>

      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        {/* Profile Header */}
        <div className="bg-white dark:bg-gray-800 rounded-xl shadow-sm p-6 mb-6">
          <div className="flex flex-col sm:flex-row items-center sm:items-start gap-6">
            {/* Avatar */}
            <div className="w-24 h-24 bg-blue-600 rounded-full flex items-center justify-center flex-shrink-0">
              <span className="text-3xl font-bold text-white">
                {mockProfile.avatarInitials}
              </span>
            </div>

            {/* Name & Bio */}
            <div className="flex-1 text-center sm:text-left">
              <h2 className="text-2xl font-bold text-gray-900 dark:text-white">
                {mockProfile.firstName} {mockProfile.lastName}
              </h2>
              <p className="text-gray-500 dark:text-gray-400 mt-1">
                @{mockProfile.username}
              </p>
              <p className="text-gray-700 dark:text-gray-300 mt-3 max-w-lg">
                {mockProfile.bio}
              </p>

              {/* Meta info */}
              <div className="flex flex-wrap justify-center sm:justify-start gap-4 mt-4">
                <span className="flex items-center gap-1 text-sm text-gray-500 dark:text-gray-400">
                  <Mail className="w-4 h-4" />
                  {mockProfile.email}
                </span>
                <span className="flex items-center gap-1 text-sm text-gray-500 dark:text-gray-400">
                  <MapPin className="w-4 h-4" />
                  {mockProfile.location}
                </span>
                <span className="flex items-center gap-1 text-sm text-gray-500 dark:text-gray-400">
                  <Calendar className="w-4 h-4" />
                  Member since {formatMemberSince(mockProfile.memberSince)}
                </span>
              </div>
            </div>
          </div>
        </div>

        {/* Stats */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-6">
          <div className="bg-white dark:bg-gray-800 rounded-xl shadow-sm p-6">
            <div className="flex items-center justify-between">
              <div>
                <p className="text-sm text-gray-500 dark:text-gray-400">
                  Total Spending
                </p>
                <p className="text-2xl font-bold text-gray-900 dark:text-white mt-1">
                  {formatCurrency(summary.totalSpending)}
                </p>
              </div>
              <div className="w-12 h-12 bg-blue-100 dark:bg-blue-900/30 rounded-full flex items-center justify-center">
                <DollarSign className="w-6 h-6 text-blue-600 dark:text-blue-400" />
              </div>
            </div>
          </div>

          <div className="bg-white dark:bg-gray-800 rounded-xl shadow-sm p-6">
            <div className="flex items-center justify-between">
              <div>
                <p className="text-sm text-gray-500 dark:text-gray-400">
                  Total Expenses
                </p>
                <p className="text-2xl font-bold text-gray-900 dark:text-white mt-1">
                  {summary.expenseCount}
                </p>
              </div>
              <div className="w-12 h-12 bg-green-100 dark:bg-green-900/30 rounded-full flex items-center justify-center">
                <TrendingUp className="w-6 h-6 text-green-600 dark:text-green-400" />
              </div>
            </div>
          </div>

          <div className="bg-white dark:bg-gray-800 rounded-xl shadow-sm p-6">
            <div className="flex items-center justify-between">
              <div>
                <p className="text-sm text-gray-500 dark:text-gray-400">
                  Categories Used
                </p>
                <p className="text-2xl font-bold text-gray-900 dark:text-white mt-1">
                  {Object.keys(summary.spendingByCategory).length}
                </p>
              </div>
              <div className="w-12 h-12 bg-purple-100 dark:bg-purple-900/30 rounded-full flex items-center justify-center">
                <Calendar className="w-6 h-6 text-purple-600 dark:text-purple-400" />
              </div>
            </div>
          </div>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
          {/* Recent Activity */}
          <div className="bg-white dark:bg-gray-800 rounded-xl shadow-sm">
            <div className="p-6 border-b border-gray-200 dark:border-gray-700">
              <h3 className="text-lg font-semibold text-gray-900 dark:text-white">
                Recent Activity
              </h3>
            </div>
            <div className="divide-y divide-gray-200 dark:divide-gray-700">
              {recentExpenses.map((expense) => (
                <div key={expense.id} className="p-4 hover:bg-gray-50 dark:hover:bg-gray-700/50 transition-colors">
                  <div className="flex items-center justify-between">
                    <div>
                      <p className="font-medium text-gray-900 dark:text-white text-sm">
                        {expense.description}
                      </p>
                      <div className="flex items-center gap-2 mt-1">
                        <span className="text-xs text-gray-500 dark:text-gray-400">
                          {expense.category}
                        </span>
                        <span className="text-xs text-gray-400 dark:text-gray-500">·</span>
                        <span className="text-xs text-gray-500 dark:text-gray-400">
                          {formatDate(expense.date)}
                        </span>
                        {expense.isRecurring && (
                          <span className="flex items-center gap-1 text-xs text-blue-600 dark:text-blue-400">
                            <Repeat className="w-3 h-3" />
                            Recurring
                          </span>
                        )}
                      </div>
                    </div>
                    <p className="font-semibold text-gray-900 dark:text-white text-sm">
                      {formatCurrency(expense.amount)}
                    </p>
                  </div>
                </div>
              ))}
            </div>
          </div>

          {/* Spending by Category */}
          <div className="bg-white dark:bg-gray-800 rounded-xl shadow-sm">
            <div className="p-6 border-b border-gray-200 dark:border-gray-700">
              <h3 className="text-lg font-semibold text-gray-900 dark:text-white">
                Spending by Category
              </h3>
            </div>
            <div className="p-6 space-y-4">
              {Object.entries(summary.spendingByCategory)
                .sort(([, a], [, b]) => b - a)
                .map(([category, amount]) => {
                  const percentage = Math.round((amount / summary.totalSpending) * 100);
                  const color = summary.categories.find((c) => c.name === category)?.color || DEFAULT_CATEGORY_COLOR;
                  return (
                    <div key={category}>
                      <div className="flex items-center justify-between mb-1">
                        <span className="text-sm font-medium text-gray-700 dark:text-gray-300">
                          {category}
                        </span>
                        <span className="text-sm text-gray-500 dark:text-gray-400">
                          {formatCurrency(amount)} · {percentage}%
                        </span>
                      </div>
                      <div className="w-full bg-gray-200 dark:bg-gray-700 rounded-full h-2">
                        <div
                          className="h-2 rounded-full"
                          style={{ width: `${percentage}%`, backgroundColor: color }}
                        />
                      </div>
                    </div>
                  );
                })}
            </div>
          </div>
        </div>
      </main>
    </div>
  );
}
