namespace UphiweSkills.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(UphiweSkills.Models.ApplicationDbContext context)
        {
            var manager = new UserManager<User>(new UserStore<User>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));


            #region Create Users
            var user = new User()
            {
                UserName = "bonga.dludla@gmail.com",
                Email = "bonga.dludla@gmail.com",
                EmailConfirmed = true
            };

            var user1 = new User()
            {
                UserName = "admin@uphiweskills.co.za",
                Email = "admin@uphiweskills.co.za",
                EmailConfirmed = true
            };

            manager.Create(user, "051991Dludl@");
            manager.Create(user1, "Huawei@2017");
            #endregion

            #region Create and assign Roles
            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            var adminUser = manager.FindByName("bonga.dludla@gmail.com");
            manager.AddToRoles(adminUser.Id, new string[] { "Admin" });

            var adminUser1 = manager.FindByName("admin@uphiweskills.co.za");
            manager.AddToRoles(adminUser1.Id, new string[] { "Admin" });
            #endregion

            #region Add Courses
            context.Courses.AddOrUpdate(
                new Course
                {
                    CourseCode = "64709",
                    CourseName = "National Certificate: Automotive Body Repair",
                    Aim = "The learner will obtain skill to prepare, maintain and repair minor accidental damage to vehicles.",
                    Duration = "10 Months",
                    Level = "NQF2",
                    CourseStructure = "{bullet}Apply sealers and cavity fillers on vehicles. {bullet}Keep the work area safe and productive. {bullet}Perform surface preparation on a body panel. {bullet}Remove, replace and align body parts. {bullet}Repair minor dents on ferrous body shell and parts. {bullet}Select and use vehicle lifting equipment. {bullet}Select, use and care for engineering hand tools. {bullet}Understand the body construction and safety features of a vehicle. {bullet}Access and use information from texts. {bullet}Apply basic knowledge of statistics and probability to influence the use of data and procedures in order to investigate life related problems. {bullet}Demonstrate understanding of rational and irrational numbers and number systems. {bullet}Identify, describe, compare, classify, explore shape and motion in 2 and 3 dimensional shapes in different contexts. {bullet}Maintain and adapt oral/signed communication. {bullet}Use language and communication in occupational learning programmes. {bullet}Use mathematics to investigate and monitor the financial aspects of personal and community life. {bullet}Work with a range of patterns and functions and solve problems. {bullet}Write/present for a defined context. {bullet}Operate a personal computer system. {bullet}Adjust headlights. {bullet}Collect and use information. {bullet}Conduct an inspection. {bullet}Cut materials using the oxy-fuel gas cutting process(manual cutting). {bullet}Develop a learning plan and a portfolio for assessment. {bullet}Explain the individual`s role within business. {bullet}Manage basic personal finance. {bullet}Perform basic welding/joining of metals. {bullet}Polish automotive painted panels. {bullet}Select, use and care for engineering power tools.",
                    CareerOpportunities = "Tradesman, Car Assessor, Body Filler, Air Bag Replacer Specialist, Motor Trimmer, Facilitator etc.",
                    EntranceRequirements = "Grade 10/N2",
                    Accreditation = "MerSETA",
                    Location = "Jacobs", // Change to Industry
                    // CourseType = Full program"
                    // number of views
                    // number of enrolments
                    HeaderImageUrl = "~/Content/Images/courses/automotive_body_repair.jpg"
                },
                new Course
                {
                    CourseCode = "64410",
                    CourseName = "National Certificate: Spray Painting",
                    Aim = "To provide the learner with a skill and an opportunity to pursue a career in spray painting.",
                    Duration = "10 Months",
                    Level = "NQF2",
                    CourseStructure = "{bullet}Identify the various types of paint, primers, material and their uses. {bullet}Keep the work area safe and productive. {bullet}Maintain spray painting equipment. {bullet}Perform basic spray painting. {bullet}Perform masking and de-masking on a vehicle. {bullet}Perform surface preparation on a body panel. {bullet}Select and use vehicle lifting equipment. {bullet}Select, use and care for engineering hand tools. {bullet}Access and use information from texts. {bullet}Apply basic knowledge of statistics and probability to influence the use of data and procedures in order to investigate life related problems. {bullet}Demonstrate understanding of rational and irrational numbers and number systems. {bullet}Identify, describe, compare, classify, explore shape and motion in 2 and 3 dimensional shapes in different contexts. {bullet}Maintain and adapt oral/signed communication. {bullet}Use language and communication in occupational learning programmes. {bullet}Use mathematics to investigate and monitor the financial aspects of personal and community life. {bullet}Work with a range of patterns and functions and solve problems. {bullet}Write / present for a defined context. {bullet}Operate a personal computer system. {bullet}Apply sealers and cavity fillers on vehicles. {bullet}Conduct an inspection. {bullet}Develop a learning plan and a portfolio for assessment. {bullet}Explain the individual`s role within business. {bullet}Manage basic personal finance. {bullet}Polish automotive painted panels. {bullet}Select, use and care for engineering power tools. {bullet}Understand the body construction and safety features of a vehicle. {bullet}Maintain the stockroom.",
                    CareerOpportunities = "Skilled Spray Painter, Automotive Refinisher, Automotive Polisher, Quality Controller Specialist.",
                    EntranceRequirements = "Grade 10/N2",
                    Accreditation = "MerSETA",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/spray_painting.jpg"
                },
                new Course
                {
                    CourseCode = "24133",
                    CourseName = "National Certificate: Construction (Roadworks) I",
                    Aim = "This qualification is for persons who work or intend to work within a construction context on a site, and who seek recognition for essential skills in construction operations in roadworks.",
                    Duration = "10-12 Months",
                    Level = "NQF2",
                    CourseStructure = "{bullet}Describe and interpret the composition, role-players, processes and role of the construction industry.{bullet}Establish and prepare a work area.{bullet}Handle, transport, store and utilize hazardous materials on a civil construction site.{bullet}Identify describe and use materials in civil engineering construction.{bullet}Implement roadside safety procedures.{bullet}Maintain records on a construction site.{bullet}Read and interpret construction drawings and specifications.{bullet}Render basic first aid.{bullet}Use and maintain small plant and equipment on a construction site.{bullet}Work in confined spaces on construction sites.{bullet}Engage in a range of speaking and listening interactions for a variety of purposes.{bullet}Identify and respond to selected literary texts.{bullet}Read and respond to a range of text types.{bullet}Write for a variety of different purposes.{bullet}Access and use information from texts.{bullet}Apply basic knowledge of statistics and probability to influence the use of data and procedures in order to investigate life related problems.{bullet}Demonstrate understanding of rational and irrational numbers and number systems.{bullet}Maintain and adapt oral communication.{bullet}Measure, estimate and calculate physical quantities and explore, describe and represent geometrical relationships in 2-dimensions in different life or workplace contexts.{bullet}Use language and communication in occupational learning programmes.{bullet}Use mathematics to investigate and monitor the financial aspects of personal and community life.{bullet}Work with a range of patterns and functions and solve problems.{bullet}Write for a defined context.{bullet}Batch and mix concrete by volume.{bullet}Develop and use keyboard skills to enter text.{bullet}Transport personnel, material and equipment using Light Delivery Vehicle.{bullet}Apply health and safety to a work area.{bullet}Apply productivity principles on a construction site.{bullet}Apply quality principles on a construction site.{bullet}Conduct a bituminous seal operation.{bullet}Demonstrate an understanding and implement environmental initiatives on a construction activity.{bullet}Erect and maintain guardrails on a road construction site.{bullet}Maintain and repair bituminous road surfaces.{bullet}Replace batter poles/boards, profiles and layer works pegs from given survey data.{bullet}Set out control point for center line and edge line marking for road marking.{bullet}Construct precast kerbs and concrete channels on a roadworks construction site.{bullet}Erect fencing.",
                    CareerOpportunities = "Roadworker, Roadwork Team Leader.",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "CETA",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/roadwork.jpg"
                },
                new Course
                {
                    CourseCode = "24173",
                    CourseName = "National Certificate: Construction (Roadworks) II",
                    Aim = "This qualification is for persons who work or intend to work within a construction context on a site, and who seek recognition for essential skills in construction operations in roadworks.",
                    Duration = "10-12 Months",
                    Level = "NQF3",
                    CourseStructure = "{bullet}Apply health and safety to a work area.{bullet}Apply quality principles on a construction site.{bullet}Establish and prepare a work area.{bullet}Handle, transport, store and utilize hazardous materials on a civil construction site.{bullet}Identify describe and use materials in civil engineering construction.{bullet}Implement roadside safety procedures.{bullet}Maintain records on a construction site.{bullet}Render basic first aid.{bullet}Work in confined spaces on construction sites.{bullet}Calculate construction quantities to develop a work plan.{bullet}Interpret the composition, construction sequence and processes of the construction industry.{bullet}Procure materials, tools and equipment.{bullet}Read and interpret construction drawings and specifications.{bullet}Access and use information from texts.{bullet}Maintain and adapt oral communication.{bullet}Use language and communication in occupational learning programmes.{bullet}Write for a defined context.{bullet}Accommodate audience and context needs in oral communication.{bullet}Demonstrate an understanding of the use of different number bases and measurement units and an awareness of error in the context of relevant calculations.{bullet}Describe, apply, analyze and calculate shape and motion in 2-and 3-dimensional space in different contexts.{bullet}Interpret and use information from texts.{bullet}Investigate life and work related problems using data and probabilities.{bullet}Use language and communication in occupational learning programmes.{bullet}Use mathematics to investigate and monitor the financial aspects of personal, business and national issues.{bullet}Write texts for a range of communicative contexts.{bullet}Develop and use keyboard skills to enter text.{bullet}Conduct a bituminous seal operation.{bullet}Erect and maintain guardrails on a road construction site.{bullet}Install manholes and chambers on a civil construction site.{bullet}Install precast concrete pipes.{bullet}Install road studs.{bullet}Maintain and repair bituminous road surfaces.{bullet}Operate a personal computer system.{bullet}Set out control point for center line and edge line marking for road marking.{bullet}Construct precast kerbs and concrete channels on a roadworks construction site.{bullet}Erect directional signs overhead < 10 m2.{bullet}Erect fencing.{bullet}Erect palisade fencing.{bullet}Organize and control the compaction of hot mix asphalt.{bullet}Plan to conduct, repair and maintain work on un-surfaced road shoulders.{bullet}Demonstrate an understanding and implement environmental initiatives on a construction project.",
                    CareerOpportunities = "Road Worker, Road Construction Worker, Roadwork Artisan.",
                    EntranceRequirements = "Grade 11",
                    Accreditation = "CETA",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/roadwork.jpg"
                },
                new Course
                {
                    CourseCode = "20813",
                    CourseName = "National Certificate: Construction (Contracting)",
                    Aim = "{bullet}Apply basic business principles to sell services, manage payment processing and conduct business in an ethical, professional manner.{bullet}Apply basic health and safety legislation in the form of standards and procedures governing health and safety in the workplace, to ensure that they contribute to a safe, healthy environment for themselves and others.{bullet}Manage quality, and to apply specifications on a construction project.",
                    Duration = "10-12 Months",
                    Level = "NQF2",
                    CourseStructure = "{bullet}Demonstrate an understanding of a general business plan and adapt it to a selected business idea.{bullet}Demonstrate an understanding of entrepreneurship and develop entrepreneurial qualities.{bullet}Demonstrate the ability to start and run a business and adapt to a changing business environment. {bullet}Identify, analyze and select business opportunities.{bullet}Apply basic business concepts.{bullet}Apply construction contract documentation.{bullet}Apply health and safety to a work area.{bullet}Apply quality principles on a construction site.{bullet}Comply with legal requirements for a construction contract.{bullet}Describe the construction industry composition its work procurement systems and communication techniques. {bullet}Implement construction site management procedures.{bullet}Implement site administration procedures on a construction project.{bullet}Manage construction resources.{bullet}Setup and manage a construction contracting business{bullet}Tender for construction contracts.{bullet}Access and use information from texts.{bullet}Apply basic knowledge of statistics and probability to influence the use of data and procedures in order to investigate life related problems.{bullet}Demonstrate understanding of rational and irrational numbers and number systems.{bullet}Maintain and adapt oral communication.{bullet}Measure, estimate and calculate physical quantities and explore, describe and represent geometrical relationships in 2-dimensions in different life or workplace contexts.{bullet}Use language and communication in occupational learning programmes.{bullet}Use mathematics to investigate and monitor the financial aspects of personal and community life.{bullet}Work with a range of patterns and functions and solve problems.{bullet}Write for a defined context.{bullet}Apply basic business concepts.{bullet}Read, analyze and respond to a variety of texts.{bullet}Apply surveying techniques on a construction contract.{bullet}Understand and apply business finances.",
                    CareerOpportunities = "This will allow persons to register as a Construction Contractor and lay a foundation for future career advancement across similar SMME programmes (entrepreneurship) in other sectors as well as to supervisory and management qualifications within the construction sector.",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "CETA",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/contracting.jpg"
                },
                new Course
                {
                    CourseCode = "49053",
                    CourseName = "National Certificate: Supervision of Construction Processes",
                    Aim = "For those with extensive experience in the workplace, this qualification can be used in the recognition of prior learning process to assess and recognise workplace skills acquired without the benefit of formal education and training. For the new entrant, this qualification describes the learning outcomes required to effectively participate in a structured workplace.",
                    Duration = "10-12 Months",
                    Level = "NQF4",
                    CourseStructure = "{bullet}Comply with legal requirements for a construction contract.{bullet}Calculate construction quantities and develop a work plan.{bullet}Demonstrate an understanding and implement environmental initiatives on a construction project.{bullet}Describe and interpret the composition, role-players, processes and role of the construction industry.{bullet}Implement a quality management system, project quality plan and a quality improvement process on a construction project.{bullet}Lead and supervise construction teams.{bullet}Monitor and control cost and production of construction work activities and implement productivity improvements.{bullet}Perform site administration functions.{bullet}Read, interpret and use construction drawings and specifications.{bullet}Supervise health and safety on a construction project.{bullet}Supervise the procurement, use and storage of construction materials.{bullet}Apply contract documentation.{bullet}Demonstrate knowledge of and produce computer spreadsheets using basic functions.{bullet}Demonstrate knowledge of and produce word processing documents using basic functions.{bullet}Accommodate audience and context needs in oral communication.{bullet}Interpret and use information from texts.{bullet}Use language and communication in occupational learning programmes.{bullet}Write texts for a range of communicative contexts.{bullet}Apply knowledge of statistics and probability to critically interrogate and effectively communicate findings on life related problems.{bullet}Engage in sustained oral communication and evaluate spoken texts.{bullet}Measure, estimate & calculate physical quantities & explore, critique & prove geometrical relationships in 2 and 3 dimensional space in the life and workplace of adult with increasing responsibilities.{bullet}Read analyze and respond to a variety of texts.{bullet}Use language and communication in occupational learning programmes.{bullet}Use mathematics to investigate and monitor the financial aspects of personal, business, national and international issues.{bullet}Write for a wide range of contexts.{bullet}Identify describe and use materials in civil engineering construction.{bullet}Demonstrate knowledge of concrete construction technology.{bullet}Implement labour intensive construction systems and techniques.{bullet}Inspect access scaffolding.{bullet}Interpret test/lab results in civil construction.{bullet}Organize and control finishing carpentry activities.{bullet}Organize and control masonry activities.{bullet}Organize and control plumbing activities.{bullet}Organize and control roof carpentry activities.{bullet}Organize and control the installation of concrete segmented paving blocks.{bullet}Organize and control the installation of jacked pipes.{bullet}Organize and control the spraying of bitumen on road surfaces.{bullet}Organize and control tiling and plastering activities.{bullet}Organize and control concreting activities.{bullet}Organize and control general road maintenance activities.{bullet}Organize and control road rehabilitation by milling.{bullet}Organize and control the construction of bulk earthworks.{bullet}Organize and control the utilization of plant and equipment in civil engineering construction.{bullet}Plan organize and control the installation of drainage structures for stormwater flow.{bullet}Plan, organize and control the construction of stabilized and unstabilized pavement layers.{bullet}Plan, organize and control the installation of Armco pipes.{bullet}Plan, organize and control the installation of pressure and gravity drainage pipes.{bullet}Plan, organize and control the maintenance of gravity drainage structures.{bullet}Plan, organize and control the maintenance of pressure pipelines.{bullet}Set out construction work areas.{bullet}Use labour intensive construction methods to construct and maintain roads and stormwater drainage.{bullet}Use labour intensive construction methods to construct and maintain water and sanitation services.{bullet}Use labour intensive construction methods to construct, repair and maintain structures.{bullet}Initiate testing and interpret test/lab results in civil construction.{bullet}Organize and control a binder manufacturing process.{bullet}Organize and control a hot mix asphalt manufacturing process.",
                    CareerOpportunities = "Learners found competent against this qualification will be able to execute the supervision of construction processes, with specialisation in a specific context. This will allow for future career advancement across the various learnerships in the supervision of construction processes (Foreman).",
                    EntranceRequirements = "Grade 12",
                    Accreditation = "CETA",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/construction.jpg"
                },
                new Course
                {
                    CourseCode = "49053",
                    CourseName = "Leadership and Supervision Skills (Construction)",
                    Aim = "It will help all managers and leaders develop the essential methods to positively impact and motivate their staff to achieve high levels of performance.",
                    Duration = "3-4 Days",
                    Level = "Apprentice",
                    CourseStructure = "{bullet}The planning, organizing, leading, controlling function is identified. Responsibility and accountability is contrasted with reference to delegation.{bullet}Identify and explain some of the tasks required of managers. Decision making task of managers, communication, and coordination is explained with examples. The delegating, disciplinary, evaluating and motivating task of managers is explained with examples.{bullet}Apply the decision making process to make a management decision. The steps to be followed in making a decision are explained with reference to an authentic workplace situation.{bullet}Apply the general management functions to a selected organisation. The management functions in an organisation are listed and an indication is given of who in the organisation is responsible for each function. The role of a team leader or low level manager in the management of an organisation is outlined with reference to the basic management functions and tasks.{bullet}Practical relevant exercises.{bullet}Speeches and presentations.{bullet}Team sessions{bullet}Practical demonstrations.{bullet}Role-plays.{bullet}Questionnaires{bullet}Discussion and case examples.",
                    CareerOpportunities = "Being a good manager in your respective field",
                    EntranceRequirements = "Grade 10/N2",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/construction.jpg"
                },
                new Course
                {
                    CourseCode = "20813",
                    CourseName = "Entrepreneurship (Construction)",
                    Aim = "The purpose of this SLP and module is to empower students with the necessary competencies, such as knowledge, skills and values, to equip them for entrepreneurial and management responsibilities in a small business; show them how to apply marketing concepts and principles relating to product, pricing, promotion and distribution strategies in the business; show them how to manage the operations of the business ethically, efficiently and effectively with respect to human resources management and production and operations management; and show them how to manage the finances and assets and evaluate the financial performance of a small business.",
                    Duration = "11-12 Weeks",
                    Level = "Apprentice",
                    CourseStructure = "{bullet}The operations and purchasing function.{bullet}The human resources function. {bullet}Introduction to financial management.{bullet}Financing the capital requirements of a small business.{bullet}The breakeven analysis.{bullet}Budgets.{bullet}Marketing and sales.{bullet}How to write a company profile and a business plan.",
                    CareerOpportunities = "{bullet}Starting your own business.{bullet}Knowledge and understanding in growing a business.{bullet}Expanding the business.",
                    EntranceRequirements = "{bullet}Existing small business owners with fewer than 50 employees who would like to enhance their management skills in preparation for business growth.{bullet}Potential entrepreneurs intending to start a business and who need the skills to manage their small business effectively.",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/entrepreneurship.jpg"
                },
                new Course
                {
                    CourseCode = "20813",
                    CourseName = "Quantities and Workplace Development (Construction)",
                    Aim = "To assist the candidate in calculating quantities and developing the workplace.",
                    Duration = "Min 5 days",
                    Level = "Apprentice",
                    CourseStructure = "{bullet}Interpret the project documentation with reference to quantities.{bullet}Calculate the required material quantities.{bullet}Estimate the required human and equipment resources.{bullet}Prepare a work plan.",
                    CareerOpportunities = "Entrepreneur",
                    EntranceRequirements = "Grade 10/N2",
                    Accreditation = "Non-accredited",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/quantities.jpg"
                },
                new Course
                {
                    CourseCode = "20813",
                    CourseName = "Tendering and Pricing (Construction)",
                    Aim = "To assist candidates to gain knowledge in tendering and knowing how to price correctly.",
                    Duration = "Min 5 days",
                    Level = "Apprentice",
                    CourseStructure = "{bullet}Procure a Tender Document.{bullet}Prepare and complete a Tender Document.{bullet}Submit a Tender Document.",
                    CareerOpportunities = "Entreprenuer, Contractor",
                    EntranceRequirements = "Grade 10/N2",
                    Accreditation = "Non-accredited",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/pricing.jpg"
                },

                new Course
                {
                    CourseCode = "49091",
                    CourseName = "Cabinet Making",
                    Aim = "To use and apply furniture making principles and processes in making cabinets",
                    Duration = "11-12 Weeks",
                    Level = "NQF3",
                    CourseStructure = "{bullet}Apply health and safety to a work area{bullet}Comply with good housekeeping practices{bullet}Read and interpret basic engineering drawings{bullet}Perform breakout operations{bullet}Produce planed timber product components and products{bullet}Produce sawn timber and board product components and products{bullet}Produce machine sanded timber and board product components and products{bullet}Produce straight laminated timber and board components{bullet}Produce basic hand crafted furniture",
                    CareerOpportunities = "Cabinet maker, Entrepreneur",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/cabinet_making.jpg"
                },
                new Course
                {
                    CourseCode = "49091",
                    CourseName = "Upholstery",
                    Aim = "To use and apply furniture making principle and processes in upholstery",
                    Duration = "11-12 Weeks",
                    Level = "NQF3",
                    CourseStructure = "{bullet}Read, interpret and produce basic engineering drawings{bullet}Apply safety, health and environmental protection procedures{bullet}Machine sew covers for upholstered items{bullet}Carry out multi-lay fabric cutting{bullet}Cover prepared frame{bullet}Prepare buttons and deep button furniture items",
                    CareerOpportunities = "Apprentice upholsterer, Entrepreneur",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/upholstery.jpg"
                },
                new Course
                {
                    CourseCode = "58277",
                    CourseName = "Industrial sewing",
                    Aim = "To use and apply sewing principles using industrial sewing machines",
                    Duration = "11-12 Weeks",
                    Level = "NQF3",
                    CourseStructure = "{bullet}Demonstrate an understanding of the regulatory occupational safety, health and environmental practices{bullet}Design and make patterns for sewn products{bullet}Join component parts",
                    CareerOpportunities = "Sewing car seats, working in factories and being an Entrepreneur",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/industrial_sewing.jpg"
                },
                new Course
                {
                    CourseCode = "58277",
                    CourseName = "Basic Sewing",
                    Aim = "To use, apply and understand basic sewing.",
                    Duration = "11-12 Weeks",
                    Level = "NQF2",
                    CourseStructure = "{bullet}Demonstrate an understanding of the regulatory occupational safety, health and environmental practices{bullet}Design and make patterns for sewn products{bullet}Join component parts",
                    CareerOpportunities = " Working in factories and being an Entrepreneur",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/basic_sewing.jpg"
                },
                new Course
                {
                    CourseCode = "58277",
                    CourseName = "Pattern Making",
                    Aim = "To use and apply basic pattern making and cutting.",
                    Duration = "11-12 Weeks",
                    Level = "NQF2",
                    CourseStructure = "{bullet}Demonstrate an understanding of the regulatory occupational safety, health and environmental practices{bullet}Design and make patterns for sewn products{bullet}Join component parts",
                    CareerOpportunities = "{bullet}Make a pattern from a sketch or photograph{bullet}Save money - commercial patterns are expensive{bullet}Set up a business in pattern-making{bullet}Portfolio of designs could lead to employment",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/pattern_making.jpg"
                },
                new Course
                {
                    CourseCode = "20813",
                    CourseName = "Read and Interpret Drawings",
                    Aim = "To use and apply basic pattern making and cutting",
                    Duration = "11-12 Weeks",
                    Level = "NQF2",
                    CourseStructure = "{bullet}Demonstrate an understanding of the regulatory occupational safety, health and environmental practices{bullet}Design and make patterns for sewn products{bullet}Join component parts",
                    CareerOpportunities = "{bullet}Make a pattern from a sketch or photograph{bullet}Save money - commercial patterns are expensive{bullet}Set up a business in pattern-making{bullet}Portfolio of designs could lead to employment",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/pattern_making.jpg"
                },
                new Course
                {
                    CourseCode = "49091",
                    CourseName = "National Certificate: Furniture Making (Wood Machining)",
                    Aim = "To use and apply furniture making principles and processes in making cabinets.",
                    Duration = "10-12 Weeks",
                    Level = "NQF2",
                    CourseStructure = "{bullet}Apply health and safety to a work area{bullet}Read and interpret basic engineering drawings{bullet}Cutting lists{bullet}Routing sheets{bullet}Jigs and templates{bullet}Mortiser{bullet}Tenoner{bullet}Overhead router{bullet}Moulder{bullet}Spindle{bullet}Multiborer{bullet}The copy lathe and edge bander",
                    CareerOpportunities = "Furniture Maker, Entrepreneur",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/wood_machining.jpg"
                },
                new Course
                {
                    CourseCode = "49091",
                    CourseName = "National Certificate: Furniture Making (Wood Finishing)",
                    Aim = "To use and apply furniture making principles and processes in making cabinets.",
                    Duration = "10-12 Weeks",
                    Level = "NQF2",
                    CourseStructure = "{bullet}Apply health and safety to a work area{bullet}Compressor{bullet}Specifications{bullet}Wood finishing theory and techniques{bullet}Colour Matching{bullet}Hand Staining{bullet}Spray Equipment{bullet}Conventional hand spraying",
                    CareerOpportunities = "Carpenter, Furniture Maker",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/wood_finishing.jpg"
                },
                new Course
                {
                    CourseCode = "49091",
                    CourseName = "National Certificate: Cabinet Making",
                    Aim = "To use and apply furniture making principles and processes in making cabinets.",
                    Duration = "10-12 Weeks",
                    Level = "NQF2",
                    CourseStructure = "{bullet}Apply health and safety to a work area{bullet}Comply with good housekeeping practices{bullet}Read and interpret basic engineering drawings{bullet}Perform breakout operations{bullet}Produce planned timber product components and products{bullet}Produce sawn timber and board product components and products{bullet}Produce machine sanded timber and board product components and products{bullet}Produce straight laminated timber and board components{bullet}Produce basic hand crafted furniture",
                    CareerOpportunities = "Cabinet Maker, Entrepreneur",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/cabinet_making.jpg"
                },
                new Course
                {
                    CourseCode = "N/A",
                    CourseName = "Apprenticeship (Section 13)",
                    Aim = "To assist individuals in their journey to become tradesmen/artisans.",
                    Duration = "24-36 Months",
                    Level = "Apprentice",
                    CourseStructure = "{bullet}Carton making{bullet}Plumbing{bullet}Upholstery{bullet}Printing machining",
                    CareerOpportunities = "Becoming an artisan in your respective field",
                    EntranceRequirements = "Grade 10/N2",
                    Accreditation = "MerSeta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/.jpg"
                },
                new Course
                {
                    CourseCode = "N/A",
                    CourseName = "Recognised Prior Learning (RPL Section 28)",
                    Aim = "To assist individuals in their journey to become tradesmen/artisans.",
                    Duration = "24-36 Weeks",
                    Level = "Apprentice",
                    CourseStructure = "{bullet}Carton making{bullet}Plumbing{bullet}Upholstery{bullet}Printing machining",
                    CareerOpportunities = "Becoming an artisan in your respective field",
                    EntranceRequirements = "Grade 10/N2",
                    Accreditation = "MerSeta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/recognized_prior_learning.jpg"
                },
                new Course
                {
                    CourseCode = "50225",
                    CourseName = "General Education and Training Certificate: General Forestry",
                    Aim = "This qualification will be useful to those who assist in general forestry activities at an entry level as part of a team. This qualification recognises entry-level skills in establishing, maintaining, protecting and harvesting plantations while enhancing safety and productivity in forestry. Protection activities include clearing fire-breaks and suppressing fires as back up, not as part of a proto-team.",
                    Duration = "10-12 Months",
                    Level = "NQF1",
                    CourseStructure = "{bullet}Apply fertilizer before and after planting.{bullet}Apply herbicides to noxious weeds.{bullet}Apply pesticides before or after planting.{bullet}Clear plantation waste by burning.{bullet}Contribute to the suppression of wildfires at basic fire-fighting level.{bullet}Debranch trees using an axe/hatchet.{bullet}Demonstrate an understanding of the principles of supply and demand, and the concept: production.{bullet}Demonstrate knowledge of key elements of commercial forestry.{bullet}Describe and explain basic safety requirements in a forestry environment.{bullet}Describe the environmental impacts of commercial forestry.{bullet}Eradicate weeds manually in a commercial environment.{bullet}Identify community issues in relation to conservation.{bullet}Identify, explain and demonstrate standard safety procedures during active wildfire suppression.{bullet}Manage personal finances.{bullet}Perform basic life support and first aid procedures.{bullet}Plan and manage time in the workplace.{bullet}Plant plantation trees.{bullet}Practice environmental awareness.{bullet}Prepare planting site using hand tools.{bullet}Understand the nature and importance of conservation.{bullet}Apply basic business ethics in a work environment.{bullet}Demonstrate an understanding of HIV/AIDS and its implications.{bullet}Demonstrate knowledge of basic safety in forestry operations.{bullet}Explain the individual`s role within business.{bullet}Identify engineering tools, material and equipment and explain the purpose and function of each.{bullet}Operate in a team.{bullet}Analyze cultural products and processes as representations of shape, space and time.{bullet}Collect, analyze, use and communicate numerical data.{bullet}Critically analyze how mathematics is used in social, political and economic relations.{bullet}Demonstrate an understanding of and use the numbering system.{bullet}Describe and represent objects and the environment in terms of shape, space, time and motion.{bullet}Engage in a range of speaking/signing and listening interactions for a variety of purposes.{bullet}Explore and use a variety of strategies to learn.{bullet}Read/view and respond to a range of text types.{bullet}Use maps to access and communicate information concerning routes, location and direction.{bullet}Working with numbers in various contexts.{bullet}Write/Sign for a variety of different purposes.{bullet}Debark trees with a hatchet and prepare bark bundles in a wattle operation.{bullet}Reduce coppice in gum plantations.{bullet}Select and space trees in commercial wattle forests.{bullet}Choke and dechoke timber during extraction with a cable yarder in a production situation.{bullet}Choke and dechoke timber during extraction with a skidding machine fitted with a winch in a production situation.{bullet}Communicate using a two-way radio system.{bullet}Load and refuel fixed wing aircraft for wildfire suppression.{bullet}Operate and maintain a motorized water pump.{bullet}Prune for access in Commercial Forestry and to ensure correct stem form.",
                    CareerOpportunities = "The majority of the learners for this qualification are likely to be working in the forestry sub-field, but without any formal qualification. There is a critical need in the industry to identify and recognise people who are able to conduct the essential operations associated with efficient and safe forestry operations. The qualification will give them the opportunity to balance their practical skills with the essential operations associated with efficient and safe forestry operations.",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/forestry.jpg"
                },
                new Course
                {
                    CourseCode = "50266",
                    CourseName = "National Certificate: Forestry (Silviculture)",
                    Aim = "This qualification will be useful to those who help to establish, maintain and protect forests within a silvicultural context, and who seek recognition for essential skills in forestry operations. The qualification recognises fairly specialised work skills with some need to supervise, instruct and organise others within routine contexts and according to given procedures.",
                    Duration = "10-12 Months",
                    Level = "NQF3",
                    CourseStructure = "{bullet}Communicate using a two-way radio system.{bullet}Conduct maintenance on herbicide applicators.{bullet}Cross-cut felled trees using a chainsaw in a production situation.{bullet}Cut felled timber using a chainsaw and maintain chainsaw.{bullet}Debranch felled trees using a chainsaw in a production situation.{bullet}Demonstrate knowledge of basic safety in forestry operations.{bullet}Fell trees with a chainsaw using the standard technique and felling levers.{bullet}Conduct basic forestry map reading.{bullet}Control activities at an airstrip during aerial wildfire suppression.{bullet}Organize forestry work team activities.{bullet}Control forestry work team activities.{bullet}Demonstrate knowledge of silviculture in commercial forestry.{bullet}Lead a strike attack force to contain or extinguish a wildfire.{bullet}Manage a controlled burn.{bullet}Manage a crew during wildfire suppression.{bullet}Manage individual and team performance.{bullet}Work as a project team member.{bullet}Accommodate audience and context needs in oral communication.{bullet}Analyze and respond to a variety of literary texts.{bullet}Demonstrate an understanding of the use of different number bases and measurement units and an awareness of error in the context of relevant calculations.{bullet}Describe, apply, analyze and calculate shape and motion in 2-and 3-dimensional space in different contexts.{bullet}Interpret and use information from texts.{bullet}Investigate life and work related problems using data and probabilities.{bullet}Use mathematics to investigate and monitor the financial aspects of personal, business and national issues.{bullet}Write texts for a range of communicative contexts.{bullet}Manage a chemical store on a forestry plantation.{bullet}Operate brush-cutters in commercial forestry.{bullet}Perform fire-lookout duties.{bullet}Scale tree lengths into log assortments in a production situation.{bullet}Select and mark trees for thinning in commercial forestry.{bullet}Operate an electronic fire surveillance facility.{bullet}Perform administrative functions during wildfire suppression.",
                    CareerOpportunities = "Becoming a tree feller, forestry worker, chainsaw operator, brush cutter or small plant operator.",
                    EntranceRequirements = "Grade 11",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/forestry.jpg"
                },
                new Course
                {
                    CourseCode = "50584",
                    CourseName = "General Education and Training Certificate: Clothing Manufacturing Processes",
                    Aim = "The General Education and Training Certificate in Clothing Manufacturing Processes is designed to meet the needs of learners who are involved in sewing processes/basic garment making in the clothing sector. This qualification reflects the needs of various community-based initiatives within the sector. This qualification provides the learner with accessibility to be employed in manufacturing processes.",
                    Duration = "10-12 Months",
                    Level = "NQF1",
                    CourseStructure = "{bullet}Assist the community to access services in accordance with their health related human rights.{bullet}Cost a garment.{bullet}Demonstrate an understanding of entrepreneurship and develop entrepreneurial qualities.{bullet}Demonstrate an understanding of how to participate effectively in the workplace.{bullet}Demonstrate an understanding of managerial expertise and administrative capabilities.{bullet}Demonstrate an understanding of the principles of supply and demand, and the concept: production.{bullet}Demonstrate the ability to start and run a business and adapt to a changing business environment.{bullet}Establish customer requirements and sell a garment.{bullet}Finish and store pressed and ironed items.{bullet}Identify, analyze and select business opportunities.{bullet}Make garments.{bullet}Perform basic life support and first aid procedures.{bullet}Plan to manage one`s time.{bullet}Source materials.{bullet}Analyze cultural products and processes as representations of shape, space and time.{bullet}Collect, analyze, use and communicate numerical data.{bullet}Critically analyze how mathematics is used in social, political and economic relations.{bullet}Demonstrate an understanding of and use the numbering system.{bullet}Describe and represent objects and the environment in terms of shape, space, time and motion.{bullet}Engage in a range of speaking/signing and listening interactions for a variety of purposes.{bullet}Identify and respond to selected literary texts.{bullet}Read/view and respond to a range of text types.{bullet}Use maps to access and communicate information concerning routes, location and direction.{bullet}Working with numbers in various contexts.{bullet}Write/Sign for a variety of different purposes.{bullet}Demonstrate an understanding of basic accounting practices.{bullet}Demonstrate an understanding of contracts and their sources.{bullet}Describe and discuss issues relating to HIV-AIDS, TB and sexually transmitted illnesses and their impact on the workplace.{bullet}Describe and show how the NQF can help me to plan a learning and career pathway.{bullet}Develop and use keyboard skills to enter text.{bullet}Operate a personal computer system.{bullet}Plan and manage personal finances.{bullet}Write and present a simple business plan.{bullet}Apply basic business concepts.{bullet}Identify the composition of a selected new venture's industry/sector and its procurement systems.{bullet}Identify work opportunities.{bullet}Manage business operations.{bullet}Manage marketing and selling processes of a new venture.{bullet}Match new venture opportunity to market needs.",
                    CareerOpportunities = "This will allow persons to register as a Clothing Manufacturer and lay a foundation for future career advancement across similar SMME programmes (entrepreneurship).",
                    EntranceRequirements = "Grade 10",
                    Accreditation = "FP&M Seta",
                    Location = "Jacobs",
                    HeaderImageUrl = "~/Content/Images/courses/basic_sewing.jpg"
                }
            );
            #endregion

            #region Add Event
            context.Events.AddOrUpdate(
               new Event
               {
                   Id = new Guid("98e4c7a9-cc5c-4e48-8264-790ad7f1cbc1"),
                   Title = "Free Sewing Workshop!!!",
                   Location = "397 Chamberlain Road, Jacobs",
                   Description = "A sewing skill acquired in a day, at no cost!",
                   EventDateTime = DateTime.ParseExact("17/feb/2018 08:00", "d/MMM/yyyy HH:mm", CultureInfo.InvariantCulture),
                   Duration = TimeSpan.Parse("07:00:00"),
                   SignUpEnabled = false
               },
               new Event
               {
                   Id = new Guid("a5ab55e6-07dd-42c1-ab6c-ca59e4e3aa56"),
                   Title = "Short Programme: Upholstery",
                   Location = "397 Chamberlain Road, Jacobs",
                   Description = "Free Automotive Upholstery Short Programme funded by FPM SETA. Requirements: - Candidates must be available for the Next 3 Months - Minimum Grade 10 - Must be between 18 - 50  years - Candidates must be based in Durban. To apply send your: 1.CV 2.Recently Certified Copy of ID 3.Recently Certified Copy of Certificates. email: applications @uphiweskills.co.za. ONLY 2 candidates will be selected. Note: NO STIPEND will be provided. Deadline Date: 18 September 2018. * If you DO NOT receive feedback within 5 days after deadline date, please consider your application unsuccessful an kindly keep an eye on our website for upcoming programmes. Thank you.",
                   SignUpEnabled = false
               }
            );
            #endregion

            #region Add Event Image
            context.EventImages.AddOrUpdate(
                new EventImage
                {
                    Id = new Guid("98e4c7a9-cc5c-4e48-8264-790ad7f1cbc1"),
                    ImageFilePath = "/Content/Images/EventImages/2018/2/98e4c7a9-cc5c-4e48-8264-790ad7f1cbc1.jpeg"
                },
                new EventImage
                {
                    Id = new Guid("a5ab55e6-07dd-42c1-ab6c-ca59e4e3aa56"),
                    ImageFilePath = "/Content/Images/EventImages/no-image-available.png"
                }
            );
            #endregion

            
        }
    }
}
