using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semester_GPA_Calculator
{
    public partial class Form1 : Form
    {
        private bool closeRequested = false; // يحدد ما إذا كان هناك طلب لإغلاق البرنامج.

        private bool isClosing = false; // يحدد ما إذا كان البرنامج في مرحلة الإغلاق.

        private bool confirmClose = false; // يحدد ما إذا تمت الموافقة على تأكيد الإغلاق.

        private bool isClearing = false; // يحدد ما إذا كانت عملية مسح الحقول جارية.

        private Control lastActiveControl; // يحتفظ بآخر عنصر تحكم كان المستخدم يعمل عليه، مثل TextBox.



        public Form1()
        {
            InitializeComponent(); // تهيئة عناصر واجهة البرنامج وإنشاؤها.

            btnClose.CausesValidation = false; // السماح بالضغط على زر الإغلاق دون تنفيذ التحقق من الحقول أولًا.

            btnClear.CausesValidation = false; // السماح بالضغط على زر المسح دون تنفيذ التحقق من الحقول أولًا.

            this.AutoValidate = AutoValidate.EnablePreventFocusChange; // تفعيل التحقق التلقائي ومنع الانتقال إلى عنصر آخر إذا فشل التحقق.

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCourse1.Focus();   // وضع المؤشر في خانة علامة المساق الأول أثناء تحميل النموذج
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtCourse1.Focus();  // وضع المؤشر في خانة علامة المساق الأول بعد ظهور النافذة للمستخدم
        }
        private void SaveLastActiveControl(object sender, EventArgs e)
        {
            if (sender is Control control)      // التأكد إن العنصر اللي أطلق الحدث هو عنصر تحكم
            {
                lastActiveControl = control;          // حفظ آخر عنصر تحكم كان المستخدم يعمل عليه، عشان يقدر البرنامج يرجعله عند الحاجة
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourse1.Text)) // التأكد من عدم ترك حقل علامة المساق الأول فارغاً من خلل استخدام دالة التحقق string.IsNullOrWhiteSpace()
            {
                MessageBox.Show("يرجى إدخال علامة المساق الأول");
                txtCourse1.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(txtHours1.Text))
            {
                MessageBox.Show("يرجى إدخال عدد ساعات المساق الأول");
                txtHours1.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(txtCourse2.Text))
            {
                MessageBox.Show("يرجى إدخال علامة المساق الثاني");
                txtCourse2.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(txtHours2.Text))
            {
                MessageBox.Show("يرجى إدخال عدد ساعات المساق الثاني");
                txtHours2.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(txtCourse3.Text))
            {
                MessageBox.Show("يرجى إدخال علامة المساق الثالث");
                txtCourse3.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(txtHours3.Text))
            {
                MessageBox.Show("يرجى إدخال عدد ساعات المساق الثالث");
                txtHours3.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(txtCourse4.Text))
            {
                MessageBox.Show("يرجى إدخال علامة المساق الرابع");
                txtCourse4.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(txtHours4.Text))
            {
                MessageBox.Show("يرجى إدخال عدد ساعات المساق الرابع");
                txtHours4.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(txtCourse5.Text))
            {
                MessageBox.Show("يرجى إدخال علامة المساق الخامس");
                txtCourse5.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(txtHours5.Text))
            {
                MessageBox.Show("يرجى إدخال عدد ساعات المساق الخامس");
                txtHours5.Focus();
                return;
            }

            // التحقق من صحة العلامات والساعات قبل الحساب

            TextBox[] courses =
            {
              txtCourse1, txtCourse2, txtCourse3, txtCourse4, txtCourse5
            };
            

            TextBox[] hoursBoxes =
            {
              txtHours1, txtHours2, txtHours3, txtHours4, txtHours5
            }; // والهدف من هذه المصفوفة هو تسهيل التحقق من عدد ساعات كل مساق داخل الحلقة نفسها التي نستخدمها لفحص العلامات

            string[] courseNames = 
            {
              "الأول", "الثاني", "الثالث", "الرابع", "الخامس"
            }; //تساعدنا في إظهار رسالة خطأ تحدد المساق الذي يحتوي على إدخال غير صحيح


            float[] product = new float[5]; // يتم فيه تخزين حاصل ضرب كل مساق في الساعات المعتمدة للمساق
            int totalHours = 0; // هذا المتغير يخزن مجموع الساعات المعتمدة للمساقات الخمسة
            

            for (int a = 0; a < product.Length; a++)
            {
                if (!float.TryParse(courses[a].Text, out float grade) || grade < 0 || grade > 100) 
                {
                    MessageBox.Show( "يرجى إدخال علامة صحيحة من 0 إلى 100 للمساق " + courseNames[a] + ".");

                    courses[a].Focus();
                    courses[a].SelectAll();
                    return;
                }

                if (!int.TryParse(hoursBoxes[a].Text, out int hours) || hours < 1 || hours > 4) 
                {
                    MessageBox.Show(  "يرجى إدخال عدد ساعات صحيح من 1 إلى 4 للمساق " + courseNames[a] + ".");

                    hoursBoxes[a].Focus();
                    hoursBoxes[a].SelectAll();
                    return;
                }

                totalHours += hours;
                product[a] = grade * hours;
            }

            // حساب المعدل
            float sum = product.Sum();
            float gpa = sum / totalHours;

            lblGPA.Text = gpa.ToString("0.00") + " %"; // هذا السطر مسؤول عن عرض المعدل للمستخدم

            if (gpa >= 90)  // تستخدم هذه الشروط لتحديد التقييم الذي يتناسب مع المعدل
            {
                lblEvaluation.Text = "ممتاز";
            }
            else if (gpa >= 80)
            {
                lblEvaluation.Text = "جيد جداً";
            }
            else if (gpa >= 70)
            {
                lblEvaluation.Text = "جيد";
            }
            else if (gpa >= 60)
            {
                lblEvaluation.Text = "مقبول";
            }
            else
            {
                lblEvaluation.Text = "راسب";
            }
        }

        private void txtCourse1_KeyDown(object sender, KeyEventArgs e)  // تتحكم في انتقال المستخدم بين حقول العلامات والساعات عند الضغط على مفتاح Enter، وتتحقق من صحة القيمة قبل الانتقال
        {
            //  لا تُنفذ تعليمات الانتقال الموجودة داخل هذا الشرط إلا عندما يكون المفتاح المضغوط هو Enter.
            if (e.KeyCode == Keys.Enter)  // e.KeyCode: يحدد المفتاح الذي ضغطه المستخدم  
            {
                e.SuppressKeyPress = true; // تعني هذه التعليمة منع معالجة ضغطة المفتاح بالطريقة الافتراضية المعتادة في عنصر التحكم

                if (float.TryParse(txtCourse1.Text, out float grade) && grade >= 0 && grade <= 100) //  هذه الشرط وظيفته التحقق من القيمة المدخلة اذا كان رقم وليس نص واذا كانت القيمة المدخلة رقم تكون بين 0 _ 100
                {
                    txtHours1.Focus(); // ينقل المؤشر إلى حقل ساعات المساق الثاني
                }
                else
                {
                    MessageBox.Show("يرجى إدخال علامة صحيحة من 0 إلى 100");

                    txtCourse1.Focus(); // لبقاء المؤشر دخل حقل المساق الاول 
                    txtCourse1.SelectAll(); // تحدد هذه التعليمة النص الموجود بالكامل داخل مربع النص
                    
                }

            }
        }

        private void txtHours1_KeyDown(object sender, KeyEventArgs e) // يتأكد البرنامج من أن القيمة عدد صحيح، وأنها تقع بين ساعة واحدة وأربع ساعات
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (int.TryParse(txtHours1.Text, out int hours) && hours >= 1 && hours <= 4)
                {
                    txtCourse2.Focus();
                }
                
                else
                {
                    MessageBox.Show("يرجى إدخال عدد الساعات المعتمدة بشكل صحيح");
                    txtHours1.Focus();
                    txtHours1.SelectAll();
                    
                }
            }
        }

        private void txtCourse2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (float.TryParse(txtCourse2.Text, out float grade) && grade >= 0 && grade <= 100)
                {
                    txtHours2.Focus();
                }
                else
                {
                    MessageBox.Show("يرجى إدخال علامة صحيحة من 0 إلى 100.");
                    txtCourse2.Focus();
                    txtCourse2.SelectAll();
                }
            }
        }

        private void txtHours2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (int.TryParse(txtHours2.Text, out int hours) && hours >= 1 && hours <= 4)
                {
                    txtCourse3.Focus();
                }
                else
                {
                    MessageBox.Show("يرجى إدخال عدد الساعات المعتمدة بشكل صحيح");
                    txtHours2.Focus();
                    txtHours2.SelectAll();
                }
            }
        }

        private void txtCourse3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (float.TryParse(txtCourse3.Text, out float grade) && grade >= 0 && grade <= 100) 
                {
                    txtHours3.Focus();
                }
                else
                {
                    MessageBox.Show("يرجى إدخال علامة صحيحة من 0 إلى 100.");
                    txtCourse3.Focus();
                    txtCourse3.SelectAll();
                }
            }
        }

        private void txtHours3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (int.TryParse(txtHours3.Text, out int hours) && hours >= 1 && hours <= 4)
                {
                    txtCourse4.Focus();
                }
                else
                {
                    MessageBox.Show("يرجى إدخال عدد الساعات المعتمدة بشكل صحيح");
                    txtHours3.Focus();
                    txtHours3.SelectAll();
                }
            }
        }

        private void txtCourse4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (float.TryParse(txtCourse4.Text, out float grade) && grade >= 0 && grade <= 100) 
                {
                    txtHours4.Focus();
                }
                else
                {
                    MessageBox.Show("يرجى إدخال علامة صحيحة من 0 إلى 100.");
                    txtCourse4.Focus();
                    txtCourse4.SelectAll();
                }
            }
        }

        private void txtHours4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (int.TryParse(txtHours4.Text, out int hours) && hours >= 1 && hours <= 4)
                {
                    txtCourse5.Focus();
                }
                else
                {
                    MessageBox.Show("يرجى إدخال عدد الساعات المعتمدة بشكل صحيح");
                    txtHours4.Focus();
                    txtHours4.SelectAll();
                }
            }
        }

        private void txtCourse5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (float.TryParse(txtCourse5.Text, out float grade) && grade >= 0 && grade <= 100) 
                {
                    txtHours5.Focus();
                }
                else
                {
                    MessageBox.Show("يرجى إدخال علامة صحيحة من 0 إلى 100.");
                    txtCourse5.Focus();
                    txtCourse5.SelectAll();
                }
            }
        }

        private void txtHours5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (int.TryParse(txtHours5.Text, out int hours) && hours >= 1 && hours <= 4) 
                {
                    btnCalculate.PerformClick(); // تطلب من البرنامج تنفيذ إجراء الضغط على زر btnCalculate برمجياً، بدلاً من مطالبة المستخدم بالذهاب إلى الزر والضغط عليه بالفأرة
                }
                else
                {
                    MessageBox.Show("يرجى إدخال عدد الساعات المعتمدة بشكل صحيح");
                    txtHours5.Focus();
                    txtHours5.SelectAll();
                }
            }
        }
        private bool IsCloseButtonUnderMouse() // دالة تُرجع قيمة منطقية تخبر البرنامج ما إذا كان مؤشر الفأرة فوق زر الإغلاق
        {
            return btnClose.Visible && btnClose.ClientRectangle.Contains(btnClose.PointToClient(Cursor.Position));
        }

        private void txtCourse1_Validating(object sender, CancelEventArgs e)  // التحقق من صحة القيمة عندما يحاول المستخدم مغادرة مربع النص، سواء انتقل إلى حقل آخر، أو ضغط على زر، أو حاول الانتقال إلى عنصر آخر في النموذج
        {
            if (isClosing || closeRequested || IsCloseButtonUnderMouse()) // وظيفته الأساسية هي: إذا كان البرنامج في حالة إغلاق، أو كان هناك طلب إغلاق، أو كان مؤشر الفأرة فوق زر الإغلاق، فتجاوز التحقق من الحقل ولا تمنع المستخدم من الخروج
            {
                e.Cancel = false;
                return;
            }

            // السماح بالانتقال إذا كان الحقل فارغًا
            if (string.IsNullOrWhiteSpace(txtCourse1.Text)) // تفحص هذه الدالة محتوى مربع النص txtCourse1 اذا كان فارغ يتم تنفذ الامر الذي داخل الاقواس
            {
                e.Cancel = false;    // إذا كان حقل العلامة فارغاً، يسمح الكود بمغادرته دون إظهار رسالة خطأ، ثم ينهي تنفيذ الدالة
                return;
            }

            // التحقق من صحة العلامة إذا أدخل المستخدم قيمة
            if (!float.TryParse(txtCourse1.Text, out float grade) || grade < 0 || grade > 100) 
            {
                MessageBox.Show("يرجى إدخال علامة صحيحة من 0 إلى 100");

                e.Cancel = true;  // يُلغى الانتقال الناتج عن عملية التحقق هذه، ويبقى التركيز عادةً في الحقل الحالي
                txtCourse1.SelectAll(); // تحدد هذه التعليمة النص الموجود داخل حقل علامة المساق الأول بالكامل.
            }
        }
        private void txtCourse2_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing || closeRequested || IsCloseButtonUnderMouse())
            {
                e.Cancel = false;
                return;
            }

            // السماح بالانتقال إذا كان الحقل فارغًا
            if (string.IsNullOrWhiteSpace(txtCourse2.Text))
            {
                e.Cancel = false;
                return;
            }

            // التحقق من صحة العلامة إذا أدخل المستخدم قيمة
            if (!float.TryParse(txtCourse2.Text, out float grade) || grade < 0 || grade > 100) 
            {
                MessageBox.Show("يرجى إدخال علامة صحيحة من 0 إلى 100");

                e.Cancel = true;
                txtCourse2.SelectAll();
            }
        }

        private void txtCourse3_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing || closeRequested || IsCloseButtonUnderMouse())
            {
                e.Cancel = false;
                return;
            }

            // السماح بالانتقال إذا كان الحقل فارغًا
            if (string.IsNullOrWhiteSpace(txtCourse3.Text))
            {
                e.Cancel = false;
                return;
            }

            // التحقق من صحة العلامة إذا أدخل المستخدم قيمة
            if (!float.TryParse(txtCourse3.Text, out float grade) ||
                grade < 0 || grade > 100)
            {
                MessageBox.Show("يرجى إدخال علامة صحيحة من 0 إلى 100");

                e.Cancel = true;
                txtCourse3.SelectAll();
            }
        }

        private void txtCourse4_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing || closeRequested || IsCloseButtonUnderMouse())
            {
                e.Cancel = false;
                return;
            }

            // السماح بالانتقال إذا كان الحقل فارغًا
            if (string.IsNullOrWhiteSpace(txtCourse4.Text))
            {
                e.Cancel = false;
                return;
            }

            // التحقق من صحة العلامة إذا أدخل المستخدم قيمة
            if (!float.TryParse(txtCourse4.Text, out float grade) ||
                grade < 0 || grade > 100)
            {
                MessageBox.Show("يرجى إدخال علامة صحيحة من 0 إلى 100");

                e.Cancel = true;
                txtCourse4.SelectAll();
            }
        }

        private void txtCourse5_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing || closeRequested || IsCloseButtonUnderMouse())
            {
                e.Cancel = false;
                return;
            }

            // السماح بالانتقال إذا كان الحقل فارغًا
            if (string.IsNullOrWhiteSpace(txtCourse5.Text))
            {
                e.Cancel = false;
                return;
            }

            // التحقق من صحة العلامة إذا أدخل المستخدم قيمة
            if (!float.TryParse(txtCourse5.Text, out float grade) ||
                grade < 0 || grade > 100)
            {
                MessageBox.Show("يرجى إدخال علامة صحيحة من 0 إلى 100");

                e.Cancel = true;
                txtCourse5.SelectAll();
            }
        }
        private void txtHours1_Validating(object sender, CancelEventArgs e)
        {


            if (isClosing || closeRequested || IsCloseButtonUnderMouse())
            {
                e.Cancel = false;
                return;
            }

            // السماح بالانتقال إذا كان الحقل فارغًا
            if (string.IsNullOrWhiteSpace(txtHours1.Text))
            {
                e.Cancel = false;
                return;
            }

            // التحقق من صحة عدد الساعات
            if (!int.TryParse(txtHours1.Text, out int hours) ||
                hours < 1 || hours > 4)
            {
                MessageBox.Show("يرجى إدخال عدد الساعات المعتمدة بشكل صحيح");

                e.Cancel = true;
                txtHours1.SelectAll();
            }
        }
        private void txtHours2_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing || closeRequested || IsCloseButtonUnderMouse())
            {
                e.Cancel = false;
                return;
            }

            // السماح بالانتقال إذا كان الحقل فارغًا
            if (string.IsNullOrWhiteSpace(txtHours2.Text))
            {
                e.Cancel = false;
                return;
            }

            // التحقق من صحة عدد الساعات
            if (!int.TryParse(txtHours2.Text, out int hours) ||
                hours < 1 || hours > 4)
            {
                MessageBox.Show("يرجى إدخال عدد الساعات المعتمدة بشكل صحيح");

                e.Cancel = true;
                txtHours2.SelectAll();
            }
        }

        private void txtHours3_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing || closeRequested || IsCloseButtonUnderMouse())
            {
                e.Cancel = false;
                return;
            }

            // السماح بالانتقال إذا كان الحقل فارغًا
            if (string.IsNullOrWhiteSpace(txtHours3.Text))
            {
                e.Cancel = false;
                return;
            }

            // التحقق من صحة عدد الساعات
            if (!int.TryParse(txtHours3.Text, out int hours) ||
                hours < 1 || hours > 4)
            {
                MessageBox.Show("يرجى إدخال عدد الساعات المعتمدة بشكل صحيح");

                e.Cancel = true;
                txtHours3.SelectAll();
            }
        }

        private void txtHours4_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing || closeRequested || IsCloseButtonUnderMouse())
            {
                e.Cancel = false;
                return;
            }

            // السماح بالانتقال إذا كان الحقل فارغًا
            if (string.IsNullOrWhiteSpace(txtHours4.Text))
            {
                e.Cancel = false;
                return;
            }

            // التحقق من صحة عدد الساعات
            if (!int.TryParse(txtHours4.Text, out int hours) ||
                hours < 1 || hours > 4)
            {
                MessageBox.Show("يرجى إدخال عدد الساعات المعتمدة بشكل صحيح");

                e.Cancel = true;
                txtHours4.SelectAll();
            }
        }

        private void txtHours5_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing || closeRequested || IsCloseButtonUnderMouse())
            {
                e.Cancel = false;
                return;
            }

            // السماح بالانتقال إذا كان الحقل فارغًا
            if (string.IsNullOrWhiteSpace(txtHours5.Text))
            {
                e.Cancel = false;
                return;
            }

            // التحقق من صحة عدد الساعات
            if (!int.TryParse(txtHours5.Text, out int hours) ||
                hours < 1 || hours > 4)
            {
                MessageBox.Show("يرجى إدخال عدد الساعات المعتمدة بشكل صحيح");

                e.Cancel = true;
                txtHours5.SelectAll();
            }
        }
        protected override void WndProc(ref Message m)  // تراقب رسائل نظام Windows لاكتشاف طلب إغلاق النافذة من علامة X، وتعطّل التحقق التلقائي من الحقول مؤقتًا قبل الإغلاق
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND &&
                (m.WParam.ToInt32() & 0xFFF0) == SC_CLOSE)
            {
                closeRequested = true;
                AutoValidate = AutoValidate.Disable;
            }

            base.WndProc(ref m);
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (confirmClose)
            {
                e.Cancel = false;
                return;
            }
            

            closeRequested = true;  // قمنا بتغير قيمة هذه المتغيرات لمنع البرنامج من تشغيل دوال التحقق Validating
            isClosing = true;
            AutoValidate = AutoValidate.Disable;

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من رغبتك في إغلاق البرنامج؟",
                "تأكيد الإغلاق",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                confirmClose = true;
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;

                confirmClose = false;
                closeRequested = false;
                isClosing = false;
                AutoValidate = AutoValidate.Disable;

                if (lastActiveControl != null &&
                    !lastActiveControl.IsDisposed &&
                    lastActiveControl.CanFocus)
                {
                    lastActiveControl.Focus();
                    lastActiveControl.Select();
                }

                AutoValidate = AutoValidate.EnablePreventFocusChange;
            }
        }


        private void btnClose_Click(object sender, EventArgs e) // تنفذ الإجراءات اللازمة عند الضغط على زر الإغلاق، وتجهّز النموذج للإغلاق ثم تطلب إغلاقه مع إظهار رسالة التأكيد من خلال حدث FormClosing
        {
            closeRequested = true;
            isClosing = true;
            AutoValidate = AutoValidate.Disable;

            this.Close(); // هذه الامر وظيفته اغلاق البرنامج لكن قبل عملية الاغلاق بتحقق من دالة FormClosing 
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من رغبتك في مسح جميع الحقول؟",
                "تأكيد المسح",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // مسح علامات المساقات
                txtCourse1.Clear();
                txtCourse2.Clear();
                txtCourse3.Clear();
                txtCourse4.Clear();
                txtCourse5.Clear();

                // مسح الساعات المعتمدة
                txtHours1.Clear();
                txtHours2.Clear();
                txtHours3.Clear();
                txtHours4.Clear();
                txtHours5.Clear();

                // مسح النتائج والتقييم
                lblGPA.Text = "";
                lblEvaluation.Text = "";

                // الانتقال إلى أول حقل
                txtCourse1.Focus();
            }
            else
            {
                // العودة إلى آخر حقل كان المستخدم يعمل عليه
                if (lastActiveControl != null &&
                    !lastActiveControl.IsDisposed &&
                    lastActiveControl.CanFocus)
                {
                    lastActiveControl.Focus();

                    if (lastActiveControl is TextBox textBox)
                    {
                        textBox.SelectAll();
                    }
                }
            }
        }

    }


}
