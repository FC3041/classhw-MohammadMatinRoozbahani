#include <iostream>
#include <cstdlib>

class MyList {
public:
    MyList() : m_size(0), m_capacity(1) {
        m_Pnums = (int*)malloc(sizeof(int) * m_capacity);
    }

    MyList(int size, int* nums) : m_size(size), m_capacity(size) {
        m_Pnums = (int*)malloc(sizeof(int) * m_capacity);
        for (int i = 0; i < m_size; i++) {
            m_Pnums[i] = nums[i];
        }
    }

    ~MyList() {
        free(m_Pnums);
    }

    void append(int x) {
        if (m_size >= m_capacity) {
            resize(m_capacity * 2);
        }
        m_Pnums[m_size++] = x;
    }

    void remove(int index) {
        if (index < 0 || index >= m_size) {
            std::cerr << "Index out of bounds" << std::endl;
            return;
        }
        for (int i = index; i < m_size - 1; i++) {
            m_Pnums[i] = m_Pnums[i + 1];
        }
        m_size--;
    }

    int get(int index) {
        if (index < 0 || index >= m_size) {
            std::cerr << "Index out of bounds" << std::endl;
            return -1;
        }
        return m_Pnums[index];
    }

    int len() const {
        return m_size;
    }

    void print() const {
        for (int i = 0; i < m_size; i++) {
            std::cout << m_Pnums[i] << " ";
        }
        std::cout << std::endl;
    }

private:
    int m_size;
    int m_capacity;
    int* m_Pnums;

    void resize(int newCapacity) {
        int* newMem = (int*)malloc(sizeof(int) * newCapacity);
        for (int i = 0; i < m_size; i++) {
            newMem[i] = m_Pnums[i];
        }
        free(m_Pnums);
        m_Pnums = newMem;
        m_capacity = newCapacity;
    }
};

int main() {
    int nums[5] = {1, 2, 3, 4, 5};
    MyList m(5, nums);

    m.append(6);
    m.append(7);
    m.print();

    std::cout << "Length of the list: " << m.len() << std::endl;

    m.remove(2);
    m.print();

    std::cout << "Element at index 3: " << m.get(3) << std::endl;

    return 0;
}