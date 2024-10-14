using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDaily.Custom {
    public class MaxHeapOnArray {
        private readonly int[] _maxHeap;
        private readonly int _heapSize;
        public int Count { get; private set; } = 0;

        public MaxHeapOnArray(int heapSize) {
            _heapSize = heapSize;
            _maxHeap = new int[heapSize + 1];
            _maxHeap[0] = 0; // not used
        }

        public int Peek() => _maxHeap[1];

        public void Push(int value) {
            Count++;
            if (Count > _heapSize) {
                Count--;
                throw new Exception("Heap is full");
            }

            _maxHeap[Count] = value;
            int index = Count;
            int parent = index / 2;

            while (_maxHeap[index] > _maxHeap[parent] && index > 1) {
                (_maxHeap[index], _maxHeap[parent]) = (_maxHeap[parent], _maxHeap[index]);
                index = parent;
                parent = index / 2;
            }
        }

        public int Pop() {
            if (Count < 1) {
                throw new Exception("Heap is empty");
            }

            int maxElement = _maxHeap[1];
            _maxHeap[1] = _maxHeap[Count];
            Count--;
            int index = 1;
            while (index <= Count) {
                int left = index * 2;
                int right = index * 2 + 1;

                if (_maxHeap[index] < _maxHeap[left] || _maxHeap[index] > _maxHeap[right]) {
                    if (_maxHeap[left] > _maxHeap[right]) {
                        (_maxHeap[index], _maxHeap[left]) = (_maxHeap[left], _maxHeap[index]);
                        index = left;
                    }
                    else {
                        (_maxHeap[index], _maxHeap[right]) = (_maxHeap[right], _maxHeap[index]);
                        index = right;
                    }
                }
                else {
                    break;
                }
            }

            return maxElement;
        }

        public override string ToString() => '[' + string.Join(", ", _maxHeap) + "]";
    }
}
