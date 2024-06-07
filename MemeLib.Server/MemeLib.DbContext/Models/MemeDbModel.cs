using MemeLib.DbContext.Configurations;
using MemeLib.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MemeLib.DbContext.Models;

[EntityTypeConfiguration(typeof(MemeDbModelConfiguration))]
public class MemeDbModel : MemeModel
{

}