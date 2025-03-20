const API_URL = '/api/BookController';

export const bookService = {
  async getBooks(page = 1, pageSize = 10) {
    const response = await fetch(`${API_URL}?page=${page}&pageSize=${pageSize}`);
    if (!response.ok) {
      throw new Error(`Erro HTTP! status: ${response.status}`);
    }
    return response.json();
  },

  async getBookById(id) {
    const response = await fetch(`${API_URL}/${id}`);
    if (!response.ok) {
      throw new Error(`Erro HTTP! status: ${response.status}`);
    }
    return response.json();
  },

  async createBook(book) {
    const response = await fetch(API_URL, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(book),
    });
    if (!response.ok) {
      throw new Error(`Erro HTTP! status: ${response.status}`);
    }
    return response.json();
  },

  async updateBook(id, book) {
    const response = await fetch(`${API_URL}/${id}`, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(book),
    });
    if (!response.ok) {
      throw new Error(`Erro HTTP! status: ${response.status}`);
    }
    return response.json();
  },

  async deleteBook(id) {
    const response = await fetch(`${API_URL}/${id}`, {
      method: 'DELETE',
    });
    if (!response.ok) {
      throw new Error(`Erro HTTP! status: ${response.status}`);
    }
    return response.json();
  }
};
