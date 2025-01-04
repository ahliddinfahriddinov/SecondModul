namespace Lesson_8
{
    public interface IMyList<T>
    {
        void AddItem(T item);
        int GetItemAt(T index);
        void RemoveItemAt(T index);
        void AddItemsRange(T[] numbers);
        void ReplaceAllItems(T oldElement, T newElement);
        int GEtItemIndex(T item);

    }
}