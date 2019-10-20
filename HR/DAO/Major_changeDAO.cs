using EFEntity;
using IDAO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Major_changeDAO : BaseDao<Major_change>, IMajor_changeDAO
    {
            public int Major_changeAdd(Major_changeModel p)
            {
                Major_change pc = new Major_change()
                {
                    check_status=p.Check_status,
                    mch_id=p.Mch_id,
                    first_kind_id=p.First_kind_id,
                    first_kind_name=p.First_kind_name,
                    second_kind_id=p.Second_kind_id,
                    second_kind_name=p.Second_kind_name,
                    third_kind_id=p.Third_kind_id,
                    third_kind_name=p.Third_kind_name,
                    major_kind_id=p.Major_kind_id,
                    major_kind_name=p.Major_kind_name,
                    major_id=p.Major_id,
                    major_name=p.Major_name,
                    new_first_kind_id=p.New_first_kind_id,
                    new_first_kind_name=p.New_first_kind_name,
                    new_second_kind_id=p.New_second_kind_id,
                    new_second_kind_name=p.New_second_kind_name,
                    new_third_kind_id=p.New_third_kind_id,
                    new_third_kind_name=p.New_third_kind_name,
                    new_major_kind_id=p.New_major_kind_id,
                    new_major_kind_name=p.New_major_kind_name,
                    new_major_id=p.New_major_id,
                    new_major_name=p.New_major_name,
                    human_id=p.Human_id,
                    human_name=p.Human_name,
                    salary_standard_id=p.Salary_standard_id,
                    salary_standard_name=p.Salary_standard_name,
                    salary_sum=p.Salary_sum,
                    new_salary_standard_id=p.New_salary_standard_id,
                    new_salary_standard_name=p.New_salary_standard_name,
                    new_salary_sum=p.New_salary_sum,
                    change_reason=p.Change_reason,
                    check_reason=p.Check_reason,
                    register=p.Register,
                    checker=p.Checker,
                    regist_time=p.Regist_time,
                    check_time=p.Check_time
                };

                return Add(pc);
            }

            public int Major_changeDelete(Major_changeModel p)
            {
                Major_change pc = new Major_change()
                {
                    check_status=p.Check_status,
                    mch_id = p.Mch_id,
                    first_kind_id = p.First_kind_id,
                    first_kind_name = p.First_kind_name,
                    second_kind_id = p.Second_kind_id,
                    second_kind_name = p.Second_kind_name,
                    third_kind_id = p.Third_kind_id,
                    third_kind_name = p.Third_kind_name,
                    major_kind_id = p.Major_kind_id,
                    major_kind_name = p.Major_kind_name,
                    major_id = p.Major_id,
                    major_name = p.Major_name,
                    new_first_kind_id = p.New_first_kind_id,
                    new_first_kind_name = p.New_first_kind_name,
                    new_second_kind_id = p.New_second_kind_id,
                    new_second_kind_name = p.New_second_kind_name,
                    new_third_kind_id = p.New_third_kind_id,
                    new_third_kind_name = p.New_third_kind_name,
                    new_major_kind_id = p.New_major_kind_id,
                    new_major_kind_name = p.New_major_kind_name,
                    new_major_id = p.New_major_id,
                    new_major_name = p.New_major_name,
                    human_id = p.Human_id,
                    human_name = p.Human_name,
                    salary_standard_id = p.Salary_standard_id,
                    salary_standard_name = p.Salary_standard_name,
                    salary_sum = p.Salary_sum,
                    new_salary_standard_id = p.New_salary_standard_id,
                    new_salary_standard_name = p.New_salary_standard_name,
                    new_salary_sum = p.New_salary_sum,
                    change_reason = p.Change_reason,
                    check_reason = p.Check_reason,
                    register = p.Register,
                    checker = p.Checker,
                    regist_time = p.Regist_time,
                    check_time = p.Check_time

                };

                return Delete(pc);
            }

            public List<Major_changeModel> Major_changeSelect()
            {
                List<Major_change> list = Select();
                List<Major_changeModel> list2 = new List<Major_changeModel>();
                foreach (Major_change item in list)
                {
                    Major_changeModel sm = new Major_changeModel()
                    {
                        Check_status=item.check_status,
                        Mch_id =item.mch_id,
                        First_kind_id =item.first_kind_id,
                        First_kind_name = item.first_kind_name,
                        Second_kind_id = item.second_kind_id,
                        Second_kind_name = item.second_kind_name,
                        Third_kind_id = item.third_kind_id,
                        Third_kind_name = item.third_kind_name,
                        Major_kind_id = item.major_kind_id,
                        Major_kind_name = item.major_kind_name,
                        Major_id = item.major_id,
                        Major_name = item.major_name,
                        New_first_kind_id = item.new_first_kind_id,
                        New_first_kind_name = item.new_first_kind_name,
                        New_second_kind_id = item.new_second_kind_id,
                        New_second_kind_name = item.new_second_kind_name,
                        New_third_kind_id = item.new_third_kind_id,
                        New_third_kind_name = item.new_third_kind_name,
                        New_major_kind_id = item.new_major_kind_id,
                        New_major_kind_name = item.new_major_kind_name,
                        New_major_id = item.new_major_id,
                        New_major_name = item.new_major_name,
                        Human_id = item.human_id,
                        Human_name = item.human_name,
                        Salary_standard_id = item.salary_standard_id,
                        Salary_standard_name = item.salary_standard_name,
                        Salary_sum = item.salary_sum,
                        New_salary_standard_id = item.new_salary_standard_id,
                        New_salary_standard_name = item.new_salary_standard_name,
                        New_salary_sum = item.new_salary_sum,
                        Change_reason = item.change_reason,
                        Check_reason = item.check_reason,
                        Register = item.register,
                        Checker = item.checker,
                        Regist_time = item.regist_time,
                        Check_time = item.check_time
                    };
                    list2.Add(sm);
                }
                return list2; ;
            }

            public List<Major_changeModel> SelectMajor_changeBy(int id)
            {
                MyDbContext db = CreateContext();
                List<Major_change> list = db.Major_change.AsNoTracking()
                      .Where(e => e.mch_id == id)
                      .Select(e => e)
                      .ToList();
                List<Major_changeModel> list2 = new List<Major_changeModel>();
                foreach (Major_change item in list)
                {
                    Major_changeModel sm = new Major_changeModel()
                    {
                        Check_status=item.check_status,
                        Mch_id = item.mch_id,
                        First_kind_id = item.first_kind_id,
                        First_kind_name = item.first_kind_name,
                        Second_kind_id = item.second_kind_id,
                        Second_kind_name = item.second_kind_name,
                        Third_kind_id = item.third_kind_id,
                        Third_kind_name = item.third_kind_name,
                        Major_kind_id = item.major_kind_id,
                        Major_kind_name = item.major_kind_name,
                        Major_id = item.major_id,
                        Major_name = item.major_name,
                        New_first_kind_id = item.new_first_kind_id,
                        New_first_kind_name = item.new_first_kind_name,
                        New_second_kind_id = item.new_second_kind_id,
                        New_second_kind_name = item.new_second_kind_name,
                        New_third_kind_id = item.new_third_kind_id,
                        New_third_kind_name = item.new_third_kind_name,
                        New_major_kind_id = item.new_major_kind_id,
                        New_major_kind_name = item.new_major_kind_name,
                        New_major_id = item.new_major_id,
                        New_major_name = item.new_major_name,
                        Human_id = item.human_id,
                        Human_name = item.human_name,
                        Salary_standard_id = item.salary_standard_id,
                        Salary_standard_name = item.salary_standard_name,
                        Salary_sum = item.salary_sum,
                        New_salary_standard_id = item.new_salary_standard_id,
                        New_salary_standard_name = item.new_salary_standard_name,
                        New_salary_sum = item.new_salary_sum,
                        Change_reason = item.change_reason,
                        Check_reason = item.check_reason,
                        Register = item.register,
                        Checker = item.checker,
                        Regist_time = item.regist_time,
                        Check_time = item.check_time
                    };
                    list2.Add(sm);
                }
                return list2;
            }

            public int Major_changeUpdate(Major_changeModel p)
            {
                Major_change pc = new Major_change()
                {
                    check_status=p.Check_status,
                    mch_id = p.Mch_id,
                    first_kind_id = p.First_kind_id,
                    first_kind_name = p.First_kind_name,
                    second_kind_id = p.Second_kind_id,
                    second_kind_name = p.Second_kind_name,
                    third_kind_id = p.Third_kind_id,
                    third_kind_name = p.Third_kind_name,
                    major_kind_id = p.Major_kind_id,
                    major_kind_name = p.Major_kind_name,
                    major_id = p.Major_id,
                    major_name = p.Major_name,
                    new_first_kind_id = p.New_first_kind_id,
                    new_first_kind_name = p.New_first_kind_name,
                    new_second_kind_id = p.New_second_kind_id,
                    new_second_kind_name = p.New_second_kind_name,
                    new_third_kind_id = p.New_third_kind_id,
                    new_third_kind_name = p.New_third_kind_name,
                    new_major_kind_id = p.New_major_kind_id,
                    new_major_kind_name = p.New_major_kind_name,
                    new_major_id = p.New_major_id,
                    new_major_name = p.New_major_name,
                    human_id = p.Human_id,
                    human_name = p.Human_name,
                    salary_standard_id = p.Salary_standard_id,
                    salary_standard_name = p.Salary_standard_name,
                    salary_sum = p.Salary_sum,
                    new_salary_standard_id = p.New_salary_standard_id,
                    new_salary_standard_name = p.New_salary_standard_name,
                    new_salary_sum = p.New_salary_sum,
                    change_reason = p.Change_reason,
                    check_reason = p.Check_reason,
                    register = p.Register,
                    checker = p.Checker,
                    regist_time = p.Regist_time,
                    check_time = p.Check_time
                };
                return Update(pc);
            }

            public List<Major_changeModel> Major_changeFenYe(int currentPage, int PageSize, out int rows)
            {
                var list = CreateContext().Major_change.AsNoTracking().OrderBy(e => e.mch_id).ToList();
                rows = list.Count();
                var data = list
                     .Skip((currentPage - 1) * PageSize)
                     .Take(PageSize)
                     .ToList();
                List<Major_changeModel> list2 = new List<Major_changeModel>();
                foreach (var item in data)
                {
                    Major_changeModel e = new Major_changeModel()
                    {
                        Check_status=item.check_status,
                        Mch_id = item.mch_id,
                        First_kind_id = item.first_kind_id,
                        First_kind_name = item.first_kind_name,
                        Second_kind_id = item.second_kind_id,
                        Second_kind_name = item.second_kind_name,
                        Third_kind_id = item.third_kind_id,
                        Third_kind_name = item.third_kind_name,
                        Major_kind_id = item.major_kind_id,
                        Major_kind_name = item.major_kind_name,
                        Major_id = item.major_id,
                        Major_name = item.major_name,
                        New_first_kind_id = item.new_first_kind_id,
                        New_first_kind_name = item.new_first_kind_name,
                        New_second_kind_id = item.new_second_kind_id,
                        New_second_kind_name = item.new_second_kind_name,
                        New_third_kind_id = item.new_third_kind_id,
                        New_third_kind_name = item.new_third_kind_name,
                        New_major_kind_id = item.new_major_kind_id,
                        New_major_kind_name = item.new_major_kind_name,
                        New_major_id = item.new_major_id,
                        New_major_name = item.new_major_name,
                        Human_id = item.human_id,
                        Human_name = item.human_name,
                        Salary_standard_id = item.salary_standard_id,
                        Salary_standard_name = item.salary_standard_name,
                        Salary_sum = item.salary_sum,
                        New_salary_standard_id = item.new_salary_standard_id,
                        New_salary_standard_name = item.new_salary_standard_name,
                        New_salary_sum = item.new_salary_sum,
                        Change_reason = item.change_reason,
                        Check_reason = item.check_reason,
                        Register = item.register,
                        Checker = item.checker,
                        Regist_time = item.regist_time,
                        Check_time = item.check_time
                    };
                    list2.Add(e);
                }
                return list2;
            }
        public List<Major_changeModel> Major_changeSelectSX(int currentPage, int pageSize, out int rows, string mkid, string mid, string gjz, DateTime? startTime, DateTime? endTime)
        {
            string sql = "select * from Major_change where 1=1 ";
            if (mkid != null && mkid != "" && mid != null && mid != ""&&gjz!=null&&gjz!="")
            {
                sql += string.Format(" and  first_kind_id={0} and second_kind_id={1} and third_kind_id={2} ", mkid, mid,gjz);
            }
            if (startTime != null && endTime != null)
            {
                sql += (string.Format(" and  regist_time>= '{0}' and check_time<='{1}' ", startTime, endTime));
            }
            var list = CreateContext().Major_change.SqlQuery(sql).Where(e=>e.check_status==0).OrderBy(e => e.mch_id).ToList();
            rows = list.Count();
            var data = list
                 .Skip((currentPage - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
            List<Major_changeModel> list2 = new List<Major_changeModel>();
            foreach (var item in data)
            {
                Major_changeModel er = new Major_changeModel()
                {
                    Check_status=item.check_status,
                    Mch_id = item.mch_id,
                    First_kind_id = item.first_kind_id,
                    First_kind_name = item.first_kind_name,
                    Second_kind_id = item.second_kind_id,
                    Second_kind_name = item.second_kind_name,
                    Third_kind_id = item.third_kind_id,
                    Third_kind_name = item.third_kind_name,
                    Major_kind_id = item.major_kind_id,
                    Major_kind_name = item.major_kind_name,
                    Major_id = item.major_id,
                    Major_name = item.major_name,
                    New_first_kind_id = item.new_first_kind_id,
                    New_first_kind_name = item.new_first_kind_name,
                    New_second_kind_id = item.new_second_kind_id,
                    New_second_kind_name = item.new_second_kind_name,
                    New_third_kind_id = item.new_third_kind_id,
                    New_third_kind_name = item.new_third_kind_name,
                    New_major_kind_id = item.new_major_kind_id,
                    New_major_kind_name = item.new_major_kind_name,
                    New_major_id = item.new_major_id,
                    New_major_name = item.new_major_name,
                    Human_id = item.human_id,
                    Human_name = item.human_name,
                    Salary_standard_id = item.salary_standard_id,
                    Salary_standard_name = item.salary_standard_name,
                    Salary_sum = item.salary_sum,
                    New_salary_standard_id = item.new_salary_standard_id,
                    New_salary_standard_name = item.new_salary_standard_name,
                    New_salary_sum = item.new_salary_sum,
                    Change_reason = item.change_reason,
                    Check_reason = item.check_reason,
                    Register = item.register,
                    Checker = item.checker,
                    Regist_time = item.regist_time,
                    Check_time = item.check_time
                };
                list2.Add(er);
            }
            return list2;
        }
        public List<Major_changeModel> Major_changeSelectSh(int currentPage, int pageSize, out int rows)
        {
            var list = CreateContext().Major_change.Where(e=>e.check_status==0).OrderBy(e => e.mch_id).ToList();
            rows = list.Count();
            var data = list
                 .Skip((currentPage - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
            List<Major_changeModel> list2 = new List<Major_changeModel>();
            foreach (var item in data)
            {
                Major_changeModel er = new Major_changeModel()
                {
                    Check_status = item.check_status,
                    Mch_id = item.mch_id,
                    First_kind_id = item.first_kind_id,
                    First_kind_name = item.first_kind_name,
                    Second_kind_id = item.second_kind_id,
                    Second_kind_name = item.second_kind_name,
                    Third_kind_id = item.third_kind_id,
                    Third_kind_name = item.third_kind_name,
                    Major_kind_id = item.major_kind_id,
                    Major_kind_name = item.major_kind_name,
                    Major_id = item.major_id,
                    Major_name = item.major_name,
                    New_first_kind_id = item.new_first_kind_id,
                    New_first_kind_name = item.new_first_kind_name,
                    New_second_kind_id = item.new_second_kind_id,
                    New_second_kind_name = item.new_second_kind_name,
                    New_third_kind_id = item.new_third_kind_id,
                    New_third_kind_name = item.new_third_kind_name,
                    New_major_kind_id = item.new_major_kind_id,
                    New_major_kind_name = item.new_major_kind_name,
                    New_major_id = item.new_major_id,
                    New_major_name = item.new_major_name,
                    Human_id = item.human_id,
                    Human_name = item.human_name,
                    Salary_standard_id = item.salary_standard_id,
                    Salary_standard_name = item.salary_standard_name,
                    Salary_sum = item.salary_sum,
                    New_salary_standard_id = item.new_salary_standard_id,
                    New_salary_standard_name = item.new_salary_standard_name,
                    New_salary_sum = item.new_salary_sum,
                    Change_reason = item.change_reason,
                    Check_reason = item.check_reason,
                    Register = item.register,
                    Checker = item.checker,
                    Regist_time = item.regist_time,
                    Check_time = item.check_time
                };
                list2.Add(er);
            }
            return list2;
        }
        public List<Major_changeModel> Major_changeSelectDcx(string mkid, string mid, string gjz,string zwfl,string zwmc, DateTime? startTime, DateTime? endTime)
        {
            string sql = "select * from Major_change where 1=1 ";
            if (mkid != null && mkid != "" && mid != null && mid != "" && gjz != null && gjz != ""&&zwfl==null&&zwfl==""&&zwmc==null&&zwmc=="")
            {
                sql += string.Format(" and  first_kind_id={0} and second_kind_id={1} and third_kind_id={2} and new_major_kind_id={3} and major_id={4}", mkid, mid, gjz,zwfl,zwmc);
            }
            if (startTime != null && endTime != null)
            {
                sql += (string.Format(" and  regist_time>= '{0}' and check_time<='{1}' ", startTime, endTime));
            }
            var list = CreateContext().Major_change.SqlQuery(sql).Where(e=>e.check_status==1).ToList();
            List<Major_changeModel> list2 = new List<Major_changeModel>();
            foreach (var item in list)
            {
                Major_changeModel er = new Major_changeModel()
                {
                    Check_status = item.check_status,
                    Mch_id = item.mch_id,
                    First_kind_id = item.first_kind_id,
                    First_kind_name = item.first_kind_name,
                    Second_kind_id = item.second_kind_id,
                    Second_kind_name = item.second_kind_name,
                    Third_kind_id = item.third_kind_id,
                    Third_kind_name = item.third_kind_name,
                    Major_kind_id = item.major_kind_id,
                    Major_kind_name = item.major_kind_name,
                    Major_id = item.major_id,
                    Major_name = item.major_name,
                    New_first_kind_id = item.new_first_kind_id,
                    New_first_kind_name = item.new_first_kind_name,
                    New_second_kind_id = item.new_second_kind_id,
                    New_second_kind_name = item.new_second_kind_name,
                    New_third_kind_id = item.new_third_kind_id,
                    New_third_kind_name = item.new_third_kind_name,
                    New_major_kind_id = item.new_major_kind_id,
                    New_major_kind_name = item.new_major_kind_name,
                    New_major_id = item.new_major_id,
                    New_major_name = item.new_major_name,
                    Human_id = item.human_id,
                    Human_name = item.human_name,
                    Salary_standard_id = item.salary_standard_id,
                    Salary_standard_name = item.salary_standard_name,
                    Salary_sum = item.salary_sum,
                    New_salary_standard_id = item.new_salary_standard_id,
                    New_salary_standard_name = item.new_salary_standard_name,
                    New_salary_sum = item.new_salary_sum,
                    Change_reason = item.change_reason,
                    Check_reason = item.check_reason,
                    Register = item.register,
                    Checker = item.checker,
                    Regist_time = item.regist_time,
                    Check_time = item.check_time
                };
                list2.Add(er);
            }
            return list2;
        }
    }
    }
