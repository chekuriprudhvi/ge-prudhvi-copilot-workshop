import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { AuthProvider, useAuth } from './context/AuthContext';
import { LoginPage } from './pages/LoginPage';
import { ExpensesPage } from './pages/ExpensesPage';
import './App.css';

function ProtectedRoute({ children }: { children: React.ReactNode }) {
  const { isAuthenticated } = useAuth();
  return isAuthenticated ? <>{children}</> : <Navigate to="/" replace />;
}

function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<LoginPage />} />
      <Route
        path="/expenses"
        element={
          <ProtectedRoute>
            <ExpensesPage />
          </ProtectedRoute>
        }
      />
      {/* TODO: Lab 3 - Add routes for budgets and categories */}
      {/* <Route path="/budgets" element={<ProtectedRoute><BudgetsPage /></ProtectedRoute>} /> */}
      {/* <Route path="/categories" element={<ProtectedRoute><CategoriesPage /></ProtectedRoute>} /> */}
      
      {/* TODO: Lab 4 - Add route for charts/analytics */}
      {/* <Route path="/analytics" element={<ProtectedRoute><AnalyticsPage /></ProtectedRoute>} /> */}
      
      {/* Catch-all redirect */}
      <Route path="*" element={<Navigate to="/" replace />} />
    </Routes>
  );
}

function App() {
  return (
    <Router>
      <AuthProvider>
        <AppRoutes />
      </AuthProvider>
    </Router>
  );
}

export default App;
