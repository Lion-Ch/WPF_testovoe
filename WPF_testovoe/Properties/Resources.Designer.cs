﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_testovoe.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WPF_testovoe.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Не удалось добавить новую запись.
        /// </summary>
        internal static string AddNewRecordError {
            get {
                return ResourceManager.GetString("AddNewRecordError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Новая запись успешно добавлена.
        /// </summary>
        internal static string AddNewRecordSuccessfully {
            get {
                return ResourceManager.GetString("AddNewRecordSuccessfully", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Все записи сохранены.
        /// </summary>
        internal static string AllRecordsSavedSuccessfully {
            get {
                return ResourceManager.GetString("AllRecordsSavedSuccessfully", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Количество не может быть меньше 0.
        /// </summary>
        internal static string AmountValidateError {
            get {
                return ResourceManager.GetString("AmountValidateError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        internal static byte[] categories {
            get {
                object obj = ResourceManager.GetObject("categories", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Запись удалена.
        /// </summary>
        internal static string DeleteRecordSuccessfully {
            get {
                return ResourceManager.GetString("DeleteRecordSuccessfully", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        internal static byte[] employees {
            get {
                object obj = ResourceManager.GetObject("employees", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Данная запись уже имеется в базе данных.
        /// </summary>
        internal static string HaveRecordInBase {
            get {
                return ResourceManager.GetString("HaveRecordInBase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Не имеется такого количества продукта на складе.
        /// </summary>
        internal static string NotHaveProduct {
            get {
                return ResourceManager.GetString("NotHaveProduct", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        internal static byte[] product {
            get {
                object obj = ResourceManager.GetObject("product", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Запись не выбрана.
        /// </summary>
        internal static string RecordSelectedError {
            get {
                return ResourceManager.GetString("RecordSelectedError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        internal static byte[] sales {
            get {
                object obj = ResourceManager.GetObject("sales", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Текстовое поле не заполнено.
        /// </summary>
        internal static string StringValidateError {
            get {
                return ResourceManager.GetString("StringValidateError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        internal static byte[] submit {
            get {
                object obj = ResourceManager.GetObject("submit", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
