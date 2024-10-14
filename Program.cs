using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;
using LeetCodeDaily.Custom;

namespace LeetCodeDaily {
    internal class Program {
        static void Main(string[] args) {
            Solution sol = new();
            Console.WriteLine(sol.MaxKelements([10, 10, 10, 10, 10], 5));
            Console.WriteLine(sol.MaxKelements([1, 10, 3, 3, 3], 3));
        }
        public class Solution {
            public long MaxKelements(int[] nums, int k) {

                MaxHeapOnArray heap = new(nums.Length);
                heap.Push(nums);

                long score = 0;
                while (k > 0) {
                    int max = heap.Pop();
                    score += max;
                    max = (int)Math.Ceiling((decimal)max / 3);
                    heap.Push(max);
                    k--;
                }

                return score;
            }
        }

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

            public bool Push(int value) {
                Count++;
                if (Count > _heapSize) {
                    Count--;
                    return false;
                }

                _maxHeap[Count] = value;
                int index = Count;
                int parent = index / 2;

                while (_maxHeap[index] > _maxHeap[parent] && index > 1) {
                    (_maxHeap[index], _maxHeap[parent]) = (_maxHeap[parent], _maxHeap[index]);
                    index = parent;
                    parent = index / 2;
                }

                return true;
            }

            public bool Push(int[] values) {
                if (Count + values.Length > _heapSize) {
                    return false;
                }

                foreach (int value in values) {
                    if (!Push(value)) {
                        return false;
                    }
                }

                return true;
            }

            public int Pop() {
                if (Count < 1) {
                    throw new Exception("Heap is empty");
                }

                int maxElement = _maxHeap[1];
                _maxHeap[1] = _maxHeap[Count];
                Count--;
                int index = 1;
                while (index <= Count / 2) {
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
}
