using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WPFHalo1.ViewModel
{
    // 모델로부터 데이터를 가져오고, 뷰에 적합한 형태로 데이터가 가공됨
    // ViewModel이 변경될 때마다 연결되어 있는 View가 갱신되어 반영됨
    // 하나의 View에는 ViewModel이 1:1로 매칭되어 있다. (view가 많은 경우 여러개의 viewmodel을 구성할 수 있다)
    public class StudentViewModel : Notifier
    {
        StudentFactory factory = new StudentFactory(); // 데이터 불러올 생성자 생성
        private IEnumerable<Student> foundStudents; // view단(*.xaml)에서 바인딩할 모델명
        public IEnumerable<Student> FoundStudents
        {
            get { return foundStudents; }
            set
            {
                foundStudents = value;
                OnPropertyChanged("FoundStudents");
            }
        }

        private Student selectedStudent; // view단에서 사용할 모델명
        public Student SelectedStudent
        {
            get { return selectedStudent;  }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }

        public StudentViewModel()
        {

        }

        // Read에서 사용할 이벤트 커맨드 생성
        private ICommand readCommand;
        public ICommand ReadCommand
        {
            get { return (this.readCommand) ?? (this.readCommand = new DelegateCommand(Read)); }
        }

        public void Read()
        {
            FoundStudents = factory.GetAllStudent();
        }
    }

    public class DelegateCommand : ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action execute;

        public DelegateCommand(Action execute)
            : this(execute, null)  // DelegateCommand 생성자 호출
        {

        }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object o)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute();
        }

        public void Execute(object o)
        {
            this.execute();
        }

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
