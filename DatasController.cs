using jiankao2.UserData;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jiankao2.Controllers
{
    [EnableCors("Mycors")]
    public class DatasController : Controller
    {
        private readonly AppDbcontext dbcontext;

        public DatasController(AppDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        //部门

        /// <summary>
        /// 获取所有待办事项
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartmentDetails()
        {
            return await dbcontext.Departments.ToListAsync();
        }
        /// <summary>
        /// 按ID获取项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(Int64 id)
        {
            var department = await dbcontext.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }
        /// <summary>s
        /// 添加新项
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment( [FromBody]Department department)
        {
           
            dbcontext.Departments.Add(department);
            await dbcontext.SaveChangesAsync();
            return CreatedAtAction("GetDepartment", new { id= department.ID },department);
        }
        /// <summary>
        /// 更新现有项
        /// </summary>
        /// <param name="id"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Department>> PostchangeDepartment([FromBody]Department department)
        {
            if (department == null || department.ID == 0)
            {
                return NotFound();
            }
            var oldDepartment = await dbcontext.Departments.FindAsync(department.ID);

            if (oldDepartment == null)
            {
                throw new ArgumentException("未找到相关部门!");
            }

            oldDepartment.部门名称 = department.部门名称;
            //dbcontext.Entry(oldDepartment).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
            return oldDepartment;
            //return department;
        }
        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Department>> PostdeleteoldDepartment([FromBody] Department department)
        {
              //if (department.ID == 0)
            //{
            //    return NotFound();
            //}
          var oldDepartment = await dbcontext.Departments.FindAsync(department.ID);
            dbcontext.Departments.Remove(oldDepartment);
            await dbcontext.SaveChangesAsync();
            return oldDepartment;
        }

        //班级

        /// <summary>
        /// 获取所有待办事项
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banji>>> GetBanjiDetails()
        {
            return await dbcontext.Banjis.ToListAsync();
        }
        /// <summary>
        /// 按ID获取项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Banji>> GetBanji(Int64 id)
        {
            var banji = await dbcontext.Banjis.FindAsync(id);
            if (banji == null)
            {
                return NotFound();
            }
            return banji;
        }
        /// <summary>s
        /// 添加新项
        /// </summary>
        /// <param name="banji"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Banji>> PostBanji([FromBody] Banji banji)
        {

            dbcontext.Banjis.Add(banji);
            await dbcontext.SaveChangesAsync();
            return CreatedAtAction("GetBanji", new { id = banji.ID }, banji);
        }
        /// <summary>
        /// 更新现有项
        /// </summary>
        /// <param name="id"></param>
        /// <param name="banji"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Banji>> PostchangeBanji([FromBody] Banji banji)
        {

            if (banji == null || banji.ID == 0)
            {
                return NotFound();
            }
            var oldBanji = await dbcontext.Banjis.FindAsync(banji.ID);
            if (oldBanji == null)
            {
                throw new ArgumentException("未找到相关班级!");
            }

            oldBanji.班级名称 = banji.班级名称;
            oldBanji.班级人数 = banji.班级人数;
            await dbcontext.SaveChangesAsync();
            return oldBanji;
        }
        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="banji"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Banji>> PostdeleteoldBanji([FromBody] Banji banji)
        {

            //if (banji.ID == 0)
            //    {
            //         throw new ArgumentException("未找到相关班级!");

            //    }
            var oldBanji = await dbcontext.Banjis.FindAsync(banji.ID);
            dbcontext.Banjis.Remove(oldBanji);
            await dbcontext.SaveChangesAsync();
            return oldBanji;
        }

        //科目

        /// <summary>
        /// 获取所有待办事项
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sub>>> GetSubDetails()
        {
            return await dbcontext.Subs.ToListAsync();
        }
        /// <summary>
        /// 按ID获取项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Sub>> GetSub(Int64 id)
        {
            var sub = await dbcontext.Subs.FindAsync(id);
            if (sub == null)
            {
                return NotFound();
            }
            return sub;
        }
        /// <summary>s
        /// 添加新项
        /// </summary>
        /// <param name="sub"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Sub>> PostSub([FromBody] Sub sub)
        {

            dbcontext.Subs.Add(sub);
            await dbcontext.SaveChangesAsync();
            return CreatedAtAction("GetSub", new { id = sub.ID }, sub);
        }
        /// <summary>
        /// 更新现有项
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sub"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Sub>> PostchangeSub([FromBody] Sub sub)
        {
            if (sub == null || sub.ID == 0)
            {
                return NotFound();
            }
            var oldSub = await dbcontext.Subs.FindAsync(sub.ID);
            if (oldSub == null)
            {
                throw new ArgumentException("未找到相关科目!");
            }
            oldSub.科目名称 = sub.科目名称;
            oldSub.科目性质 = sub.科目性质;

            await dbcontext.SaveChangesAsync();
            return oldSub;
        }
        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="sub"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Sub>> PostdeleteoldSub([FromBody] Sub sub)
        {
            var oldSub = await dbcontext.Subs.FindAsync(sub.ID);
            //if (sub == null)
            //{
            //    return NotFound();
            //}
            dbcontext.Subs.Remove(oldSub);
            await dbcontext.SaveChangesAsync();
            return oldSub;
        }

        //人员

        /// <summary>
        /// 获取所有待办事项
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffDetails()
        {
            var staff = dbcontext.Staffs
                        .Include(s => s.Department);
            return await staff.ToListAsync();
        }
        /// <summary>
        /// 按ID获取项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Staff>> GetStaff(Int64 id)
        {

            var staff = await dbcontext.Staffs
            .Include(s => s.Department)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (staff == null)
            {
                return NotFound();
            }
            return staff;
        }
        /// <summary>
        /// 添加新项
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff([FromBody] Staff staff)
        {
            //staff.Department.ID = Department.;
            dbcontext.Staffs.Add(staff);
            await dbcontext.SaveChangesAsync();
            return CreatedAtAction("GetStaff", new { id = staff.ID }, staff);
        }
        /// <summary>
        /// 更新现有项
        /// </summary>
        /// <param name="id"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task<ActionResult<Staff>> PostchangeStaff([FromBody] Staff staff)
        {
            if (staff == null || staff.ID == 0)
            {
                return NotFound();
            }
            var oldStaff = await dbcontext.Staffs
            .Include(s => s.Department)
            .FirstOrDefaultAsync(s => s.ID == staff.ID);

            if (oldStaff == null)
            {
                throw new ArgumentException("未找到相关人员!");
            }


            oldStaff.姓名 = staff.姓名;
            oldStaff.状态 = staff.状态;
            oldStaff.Department.ID = staff.Department.ID;
            //dbcontext.Entry(oldStaff).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
            return oldStaff;
        }
        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Staff>> PostdeleteoldStaff([FromBody] Int64 id)

        {
            var oldStaff = await dbcontext.Staffs
             .Include(s => s.Department)
             .FirstOrDefaultAsync( f=> f.ID==id);

            //if (staff == null)
            //{
            //    return NotFound();
            //}
            dbcontext.Staffs.Remove(oldStaff);
            await dbcontext.SaveChangesAsync();
            return oldStaff;
        }

        //科目信息

        /// <summary>
        /// 获取所有待办事项
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<Information>>> GetInformationDetails()
        {
            var information = dbcontext.Informations
                        .Include(i => i.Sub)
                        .Include(i => i.Banji)
                        .Include(i => i.Place);
            return await information.ToListAsync();
        }
        /// <summary>
        /// 按ID获取项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Information>> GetInformation(Int64 id)
        {
            //var information = await dbcontext.Informations.FindAsync(id);
            var information = await dbcontext.Informations
                        .Include(i => i.Sub)
                        .Include(i => i.Banji)
                        .Include(i => i.Place)
                        .FirstOrDefaultAsync(i => i.ID == id);

            if (information == null)
            {
                return NotFound();
            }
            return information;
        }
        /// <summary>
        /// 添加新项
        /// </summary>
        /// <param name="information"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Information>> Postinformation(Information information)
        {
            information.ID = information.ID;
            dbcontext.Informations.Add(information);
            await dbcontext.SaveChangesAsync();
            return CreatedAtAction("GetInformation", new { id = information.ID }, information);
        }
        /// <summary>
        /// 更新现有项
        /// </summary>
        /// <param name="id"></param>
        /// <param name="information"></param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public async Task<ActionResult<Information>> PutInformation(Int64 id, Information information)
        {

            var oldInformation = await dbcontext.Informations
                        .Include(i => i.Sub)
                        .Include(i => i.Banji)
                        .Include(i => i.Place)
                        .FirstOrDefaultAsync(i => i.ID == id);

            oldInformation.Sub.科目名称 = information.Sub.科目名称;
            oldInformation.Banji.班级名称 = information.Banji.班级名称;
            oldInformation.Place.教室地点 = information.Place.教室地点;
            oldInformation.考试时间 = information.考试时间;
            oldInformation.领卷地点 = information.领卷地点;
            oldInformation.领卷日期 = information.领卷日期;
            oldInformation.备注 = information.备注;

            await dbcontext.SaveChangesAsync();
            return oldInformation;
        }
        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Information>> DeleteoldInformationf(Int64 id)

        {
            var information = await dbcontext.Informations
                        .Include(i => i.Sub)
                        .Include(i => i.Banji)
                        .Include(i => i.Place)
                        .FirstOrDefaultAsync(i => i.ID == id);

            if (information == null)
            {
                return NotFound();
            }
            dbcontext.Informations.Remove(information);
            await dbcontext.SaveChangesAsync();
            return information;
        }
    }
}
