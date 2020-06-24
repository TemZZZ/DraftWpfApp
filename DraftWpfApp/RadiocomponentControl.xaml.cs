using System;
using System.Collections.Generic;
using System.Windows.Controls;


namespace DraftWpfApp
{
    /// <summary>
    /// Interaction logic for RadiocomponentControl.xaml
    /// </summary>
    public partial class RadiocomponentControl : UserControl
    {
        private Dictionary<RadioButton, int> _radioButtonToIntMap;

        /// <summary>
        /// Создает и инициализирует элемент управления
        /// <see cref="RadiocomponentControl"/>
        /// </summary>
        public RadiocomponentControl()
        {
            InitializeComponent();
            InitializeRadioButtonToUintMap();
        }

        /// <summary>
        /// Позволяет получить или задать текст текстового блока отображения
        /// физической величины и единицы измерения
        /// </summary>
        public string QuantityUnitText
        {
            get => quantityUnitTextBlock.Text;
            set => quantityUnitTextBlock.Text = value;
        }

        /// <summary>
        /// Позволяет получить или задать текст текстового поля ввода
        /// значения физической величины
        /// </summary>
        public string ValueText
        {
            get => valueTextBox.Text;
            set => valueTextBox.Text = value;
        }

        /// <summary>
        /// Позволяет получить или задать номер отмеченной радиокнопки
        /// </summary>
        public int? CheckedRadioButtonNumber
        {
            get
            {
                foreach (var radioButton in _radioButtonToIntMap.Keys)
                {
                    if (radioButton.IsChecked == true)
                    {
                        return _radioButtonToIntMap[radioButton];
                    }
                }
                return null;
            }

            set
            {
                if (value is null)
                {
                    UncheckAllRadioButtons();
                    return;
                }

                if ((value < 0) || (value > _radioButtonToIntMap.Count))
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(CheckedRadioButtonNumber),
                        "RadioButton number must be 0, 1, 2 or null.");
                }

                foreach (var radioButtonIntPair in _radioButtonToIntMap)
                {
                    if (radioButtonIntPair.Value == value)
                    {
                        radioButtonIntPair.Key.IsChecked = true;
                    }
                }
            }
        }

        /// <summary>
        /// Инициализирует словарь, ставящий в соответствие радиокнопкам их
        /// номера
        /// </summary>
        private void InitializeRadioButtonToUintMap()
        {
            _radioButtonToIntMap = new Dictionary<RadioButton, int>
            {
                [resistorRadioButton] = 0,
                [inductorRadioButton] = 1,
                [capacitorRadioButton] = 2
            };
        }

        /// <summary>
        /// Делает все радиокнопки неотмеченными
        /// </summary>
        private void UncheckAllRadioButtons()
        {
            foreach (var radioButton in _radioButtonToIntMap.Keys)
            {
                if (radioButton.IsChecked == true)
                {
                    radioButton.IsChecked = false;
                    return;
                }
            }
        }
    }
}
