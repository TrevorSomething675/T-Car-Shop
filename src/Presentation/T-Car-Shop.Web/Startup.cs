using T_Car_Shop.Application.Repositories;
using T_Car_Shop.DataAccess.Repositories;
using T_Car_Shop.Infrastructure.Services;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Application.Services;
using T_Car_Shop.DataAccess.Contexts;
using T_Car_Shop.Infrastructure;
using T_Car_Shop.Web.Extensions;
using System.Reflection;

namespace T_Car_Shop.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppOptions();
            services.AddAppMinio();
            services.AddAppDbContext();
            services.AddAppAutoMapper();
            services.AddCors();

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IMinioService, MinioService>();
			services.AddScoped<ICarService, CarService>();

            using (var context = services.BuildServiceProvider().GetRequiredService<MainContext>())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                if (!context.Manufacturers.Any())
                {
                    context.Manufacturers.Add(new ManufacturerEntity { Name = "BMW" });
                    context.SaveChanges();

                }
                if (!context.Cars.Any())
                {
                    var manufacturer = context.Manufacturers.FirstOrDefault();

                    var cars = new List<CarEntity>
                    {
                        new CarEntity{
                            Name = "BMW 5 серии 2012",
                            Description = "BMW 5 серии 2012 года - это роскошный и элегантный седан премиум-класса, сочетающий " +
									"в себе высокий уровень комфорта, динамичную производительность и передовые технологии. Автомобиль отличается изысканным " +
									"дизайном и вниманием к деталям, что делает его одним из популярных выборов среди ценителей авто во всем мире.",
							Price = 1899000,
							OldPrice = 2399999,
							Manufacturer = manufacturer,
                            Images = new List<ImageEntity>
                            {
                                new ImageEntity
                                {
									Name = "BMW 5 серии 2012-1",
									Path = "cars-image-bucket/BMW 5 серии 2012-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 5 серии 2012-2",
									Path = "cars-image-bucket/BMW 5 серии 2012-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 5 серии 2012-3",
									Path = "cars-image-bucket/BMW 5 серии 2012-3.jpg"
								}
							}
                        },
                        new CarEntity{
                            Name = "BMW X3 2018",
                            Manufacturer = manufacturer,
							Description = "BMW X3 2018 - это кроссовер класса люкс, который сочетает в себе высокую производительность, комфорт " +
									"и стильный дизайн. Автомобиль оснащен мощным двигателем, который обеспечивает плавное ускорение и отличную управляемость" +
									" на дороге. Внутреннее пространство выполнено из высококачественных материалов, создавая атмосферу роскоши и комфорта" +
									" для пассажиров. BMW X3 2018 также обладает передовыми технологиями, включая инфотейнмент систему, навигацию и системы" +
									" безопасности, что делает его идеальным выбором для тех, кто ценит высокий уровень комфорта и безопасности при вождении.",
							Price = 4399000,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X3 2018-1",
									Path = "cars-image-bucket/BMW X3 2018-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X3 2018-2",
									Path = "cars-image-bucket/BMW X3 2018-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X3 2018-3",
									Path = "cars-image-bucket/BMW X3 2018-3.jpg"
								}
							}
						},
                        new CarEntity{
                            Name = "BMW 4 серии 2014",
                            Description = "BMW 4 серии 2014 года - это стильный и спортивный автомобиль с элегантным дизайном кузова" +
									" и высоким уровнем производительности. Он оснащен мощным двигателем, который обеспечивает высокую динамику " +
									"и отличную управляемость. В салоне автомобиля присутствует высококачественная отделка и передовые технологии," +
									" которые обеспечивают комфорт и безопасность во время поездок. BMW 4 серии 2014 - это идеальный выбор для тех," +
									" кто ценит стиль, качество и динамичный образ жизни.",
							Manufacturer = manufacturer,
							Price = 2899000,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW 4 серии 2014-1",
									Path = "cars-image-bucket/BMW 4 серии 2014-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 4 серии 2014-2",
									Path = "cars-image-bucket/BMW 4 серии 2014-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 4 серии 2014-3",
									Path = "cars-image-bucket/BMW 4 серии 2014-3.jpg"
								}
							}
						},
						new CarEntity{
							Name = "BMW 5 серии 2012",
                            Description = "BMW 5 серии 2012 года - это роскошный и элегантный седан премиум-класса, сочетающий " +
									"в себе высокий уровень комфорта, динамичную производительность и передовые технологии. Автомобиль отличается изысканным " +
									"дизайном и вниманием к деталям, что делает его одним из популярных выборов среди ценителей авто во всем мире.",
							Manufacturer = manufacturer,
							Price = 1899000,
							Images = new List<ImageEntity> {
								new ImageEntity
								{
									Name = "BMW 5 серии 2012-1",
									Path = "cars-image-bucket/BMW 5 серии 2012-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 5 серии 2012-2",
									Path = "cars-image-bucket/BMW 5 серии 2012-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 5 серии 2012-3",
									Path = "cars-image-bucket/BMW 5 серии 2012-3.jpg"
								}
							}
						},
						new CarEntity{
							Name = "BMW X5 2017",
							Description = "BMW X5 2017 - это внушительный и роскошный SUV, который сочетает в себе высокую производительность и стильный дизайн. " +
									"Этот автомобиль оснащен мощным и эффективным двигателем, который обеспечивает плавное и быстрое ускорение. Салон X5 2017 выполнен из " +
									"высококачественных материалов, с элегантным дизайном и множеством современных технологий, таких как навигационная система, система " +
									"управления мультимедиа и светодиодные фары. Кроме того, этот автомобиль обладает прекрасной управляемостью и комфортной поездкой как" +
									" по городским улицам, так и на открытых дорогах. BMW X5 2017 - идеальный выбор для тех, кто ценит роскошь и динамичность в одном автомобиле.",
							Manufacturer = manufacturer,
							Price = 3688000,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X5 2017-1",
									Path = "cars-image-bucket/BMW X5 2017-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X5 2017-2",
									Path = "cars-image-bucket/BMW X5 2017-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X5 2017-3",
									Path = "cars-image-bucket/BMW X5 2017-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X6 2015",
							Description = "BMW X6 2015 - это роскошный и стильный кроссовер, который сочетает в себе " +
									"элегантный дизайн, высокую производительность и передовые технологии. Этот автомобиль оборудован " +
									"мощным двигателем, обеспечивающим плавное и динамичное ускорение, а также комфортным салоном с " +
									"премиальными материалами и передовыми системами безопасности. BMW X6 2015 идеально подойдет как " +
									"для ежедневных поездок по городу, так и для путешествий на дальние расстояния, предоставляя своему" +
									" владельцу высочайший уровень комфорта и удовольствия от вождения.",
							Manufacturer = manufacturer,
							Price = 3980000,
							OldPrice = 4299999,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X6 2015-1",
									Path = "cars-image-bucket/BMW X6 2015-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 2015-2",
									Path = "cars-image-bucket/BMW X6 2015-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 2015-3",
									Path = "cars-image-bucket/BMW X6 2015-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X6 M 2023",
							Description = "BMW X6 M 2023 - это мощный и элегантный спортивный кроссовер, " +
									"который предлагает уникальное сочетание стиля, комфорта и производительности. " +
									"Автомобиль оснащен высокотехнологичным двигателем мощностью более 600 лошадиных " +
									"сил, что позволяет ему разгоняться до 100 км/ч всего за несколько секунд. Особенности " +
									"данной модели включают в себя спортивный дизайн с агрессивными линиями, большие диски с " +
									"покрышками высокого класса, а также улучшенную аэродинамику для максимальной производительности. " +
									"Внутреннее пространство автомобиля оборудовано самыми современными технологиями, включая " +
									"цифровую приборную панель, мультимедийную систему и систему навигации. BMW X6 M 2023 " +
									"идеально подойдет для тех, кто ценит роскошь, комфорт и скорость. Этот автомобиль будет " +
									"отличным выбором для тех, кто желает иметь идеальное сочетание производительности и стиля.",
							Manufacturer = manufacturer,
							Price = 23689000,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X6 M 2023-1",
									Path = "cars-image-bucket/BMW X6 M 2023-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 M 2023-2",
									Path = "cars-image-bucket/BMW X6 M 2023-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 M 2023-3",
									Path = "cars-image-bucket/BMW X6 M 2023-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X5 M 2021",
							Description = "BMW X5 M 2021 - это спортивный внедорожник высшего класса, сочетающий в себе мощность, роскошь и" +
									" технологии. Он оснащен мощным 4,4-литровым твин-турбо V8 двигателем, который развивает более 600 лошадиных сил. " +
									"Современные технологии и системы безопасности делают вождение комфортным и безопасным. Внутри автомобиля просторный " +
									"и роскошный салон, оборудованный самыми современными возможностями развлечений и комфорта. BMW X5 M 2021 - идеальный " +
									"выбор для тех, кто ценит роскошное и высокотехнологичное вождение.",
							Manufacturer = manufacturer,
							Price = 14999000,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X5 M 2021-1",
									Path = "cars-image-bucket/BMW X5 M 2021-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X5 M 2021-2",
									Path = "cars-image-bucket/BMW X5 M 2021-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X5 M 2021-3",
									Path = "cars-image-bucket/BMW X5 M 2021-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW 2 серии 2020",
							Description = "BMW 2 серии 2020 - это стильный и спортивный автомобиль, созданный для настоящих ценителей динамичного вождения. " +
									"Он сочетает в себе элегантный дизайн и высокую производительность. В этой модели использованы самые современные технологии и " +
									"инновационные функции, которые делают ее одним из лидеров в своем классе. В салоне BMW 2 серии 2020 вы найдете премиальные " +
									"материалы, удобные сиденья и передовую информационно-развлекательную систему. Этот автомобиль предлагает отличную управляемость, " +
									"динамичное ускорение и надежность на любой дороге.",
							Manufacturer = manufacturer,
							Price = 3250000,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW 2 серии 2020-1",
									Path = "cars-image-bucket/BMW 2 серии 2020-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 2 серии 2020-2",
									Path = "cars-image-bucket/BMW 2 серии 2020-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 2 серии 2020-3",
									Path = "cars-image-bucket/BMW 2 серии 2020-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X1 2020",
							Manufacturer = manufacturer,
							Description = "BMW X1 2020 - это стильный и производительный кроссовер компактного класса, который" +
									" сочетает в себе спортивный дизайн, комфорт и технологии наивысшего уровня. Автомобиль оснащен мощным" +
									" и экономичным двигателем, обеспечивающим отличную динамику и управляемость на дороге. Внутреннее " +
									"пространство удобно и функционально организовано, современные системы безопасности и развлечений " +
									"обеспечивают высокий уровень комфорта и удовольствия от вождения. BMW X1 2020 - это идеальный выбор " +
									"для тех, кто ценит надежность, стиль и инновации в автомобильном мире.",
							Price = 4199000,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X1 2020-1",
									Path = "cars-image-bucket/BMW X1 2020-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X1 2020-2",
									Path = "cars-image-bucket/BMW X1 2020-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X1 2020-3",
									Path = "cars-image-bucket/BMW X1 2020-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW 3 серии 2013",
							Description = "BMW 3 Серия 2013 года - это стильное и спортивное седан, сочетающее в себе роскошный дизайн," +
									" высокие технологии и динамичные характеристики. Автомобиль оснащен мощными бензиновыми и дизельными двигателями," +
									" которые обеспечивают отличную производительность и динамику. Внутри салон выполнен из высококачественных" +
									" материалов, и предлагает просторное пространство для пассажиров и багажа. Также в автомобиле присутствует" +
									" множество передовых технологий, таких как система навигации, адаптивный круиз-контроль, система помощи при" +
									" парковке и многое другое. BMW 3 Серия 2013 года является идеальным выбором для тех, кто ценит комфорт, стиль " +
									"и высокую производительность.",
							Price = 4199000,
							Manufacturer = manufacturer,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW 3 серии 2013-1",
									Path = "cars-image-bucket/BMW 3 серии 2013-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 3 серии 2013-2",
									Path = "cars-image-bucket/BMW 3 серии 2013-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 3 серии 2013-3",
									Path = "cars-image-bucket/BMW 3 серии 2013-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X6 2021",
							Description = "BMW X6 2021 - это элегантный и мощный кроссовер, который привлекает внимание своим " +
									"динамичным дизайном и выдающейся производительностью. Снаружи автомобиль имеет агрессивный и спортивный " +
									"стиль, с выразительными линиями и характерной решеткой радиатора.Внутри X6 2021 просторный и уютный салон, " +
									"оформленный высококачественными материалами, современной технологией и эргономичным дизайном. " +
									"Водитель и пассажиры могут наслаждаться комфортабельными сиденьями, удобным мультимедийным " +
									"интерфейсом и полным набором современных опций.Под капотом BMW X6 2021 можно найти мощные" +
									" бензиновые и дизельные двигатели, которые обеспечивают высокую производительность и эффективность." +
									" Автомобиль оснащен передовыми системами безопасности и управления, что делает его одним из лучших выборов в своем классе.",
							Price = 11479000,
							Manufacturer = manufacturer,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X6 2021-1",
									Path = "cars-image-bucket/BMW X6 2021-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 2021-2",
									Path = "cars-image-bucket/BMW X6 2021-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 2021-3",
									Path = "cars-image-bucket/BMW X6 2021-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X1 2011",
							Description = "BMW X1 2011 - премиальный компактный кроссовер от немецкого производителя BMW. Автомобиль " +
									"отличается стильным и динамичным дизайном, характерным для всех моделей бренда BMW. Внутри X1 2011 предлагает" +
									" просторный и комфортабельный салон с качественными материалами отделки. Автомобиль оснащен мощными и " +
									"эффективными двигателями, которые обеспечивают отличную динамику и экономичность. BMW X1 2011 также обладает" +
									" отличной управляемостью и уверенным поведением на дороге благодаря передовой технологии подвески и системы " +
									"управления. Этот автомобиль идеально подходит для городской езды и дальних поездок, сочетая в себе стиль, комфорт и производительность.",
							Manufacturer = manufacturer,
							Price = 1289000,
							OldPrice = 1599999,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X1 2011-1",
									Path = "cars-image-bucket/BMW X1 2011-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X1 2011-2",
									Path = "cars-image-bucket/BMW X1 2011-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X1 2011-3",
									Path = "cars-image-bucket/BMW X1 2011-3.jpg"
								}
							}
						}
					};
                    context.Cars.AddRange(cars);
                    context.SaveChanges();
                }
            }

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(AssemblyMarker))));
			services.AddControllers();

			services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseAppAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Car}/{action=Get}");
            });
        }
    }
}