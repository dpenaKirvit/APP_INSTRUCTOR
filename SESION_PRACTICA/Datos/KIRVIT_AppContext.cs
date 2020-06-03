using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SESION_PRACTICA.Datos
{
    public partial class KIRVIT_AppContext : DbContext
    {
        public KIRVIT_AppContext()
        {
        }

        public KIRVIT_AppContext(DbContextOptions<KIRVIT_AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acciones> Acciones { get; set; }
        public virtual DbSet<AreasAcademicas> AreasAcademicas { get; set; }
        public virtual DbSet<AuditDataItemPersistent> AuditDataItemPersistent { get; set; }
        public virtual DbSet<AuditedObjectWeakReference> AuditedObjectWeakReference { get; set; }
        public virtual DbSet<Certificaciones> Certificaciones { get; set; }
        public virtual DbSet<CheckList> CheckList { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<DashboardData> DashboardData { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Etiqueta> Etiqueta { get; set; }
        public virtual DbSet<EvaluacionPractica> EvaluacionPractica { get; set; }
        public virtual DbSet<EvaluacionTeorica> EvaluacionTeorica { get; set; }
        public virtual DbSet<FileData> FileData { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Hcategory> Hcategory { get; set; }
        public virtual DbSet<HistorialAcademico> HistorialAcademico { get; set; }
        public virtual DbSet<Instalacion> Instalacion { get; set; }
        public virtual DbSet<Institución> Institución { get; set; }
        public virtual DbSet<Instrumento> Instrumento { get; set; }
        public virtual DbSet<KpiDefinition> KpiDefinition { get; set; }
        public virtual DbSet<KpiHistoryItem> KpiHistoryItem { get; set; }
        public virtual DbSet<KpiInstance> KpiInstance { get; set; }
        public virtual DbSet<KpiScorecard> KpiScorecard { get; set; }
        public virtual DbSet<KpiScorecardScorecardsKpiInstanceIndicators> KpiScorecardScorecardsKpiInstanceIndicators { get; set; }
        public virtual DbSet<LabelSignalsEtiquetas> LabelSignalsEtiquetas { get; set; }
        public virtual DbSet<MaterialApoyo> MaterialApoyo { get; set; }
        public virtual DbSet<MateriasPrácticas> MateriasPrácticas { get; set; }
        public virtual DbSet<MateriasPrácticasMateriasPrácticasCursoCursos> MateriasPrácticasMateriasPrácticasCursoCursos { get; set; }
        public virtual DbSet<MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos> MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos { get; set; }
        public virtual DbSet<MateriasTeóricas> MateriasTeóricas { get; set; }
        public virtual DbSet<MateriasTeóricasMateriasTeóricasCursoCursos> MateriasTeóricasMateriasTeóricasCursoCursos { get; set; }
        public virtual DbSet<MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos> MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos { get; set; }
        public virtual DbSet<ModelDifference> ModelDifference { get; set; }
        public virtual DbSet<ModelDifferenceAspect> ModelDifferenceAspect { get; set; }
        public virtual DbSet<ParametroInicial> ParametroInicial { get; set; }
        public virtual DbSet<PermissionPolicyActionPermissionObject> PermissionPolicyActionPermissionObject { get; set; }
        public virtual DbSet<PermissionPolicyMemberPermissionsObject> PermissionPolicyMemberPermissionsObject { get; set; }
        public virtual DbSet<PermissionPolicyNavigationPermissionsObject> PermissionPolicyNavigationPermissionsObject { get; set; }
        public virtual DbSet<PermissionPolicyObjectPermissionsObject> PermissionPolicyObjectPermissionsObject { get; set; }
        public virtual DbSet<PermissionPolicyRole> PermissionPolicyRole { get; set; }
        public virtual DbSet<PermissionPolicyTypePermissionsObject> PermissionPolicyTypePermissionsObject { get; set; }
        public virtual DbSet<PermissionPolicyUser> PermissionPolicyUser { get; set; }
        public virtual DbSet<PermissionPolicyUserUsersPermissionPolicyRoleRoles> PermissionPolicyUserUsersPermissionPolicyRoleRoles { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PersonaEstudiantesGrupoGruposEstudiantes> PersonaEstudiantesGrupoGruposEstudiantes { get; set; }
        public virtual DbSet<PersonaInstructoresGrupoGruposInstructores> PersonaInstructoresGrupoGruposInstructores { get; set; }
        public virtual DbSet<PuntosCalibracionInstrumentos> PuntosCalibracionInstrumentos { get; set; }
        public virtual DbSet<Reaccion> Reaccion { get; set; }
        public virtual DbSet<Reacciones> Reacciones { get; set; }
        public virtual DbSet<ReportDataV2> ReportDataV2 { get; set; }
        public virtual DbSet<SenalElectronica> SenalElectronica { get; set; }
        public virtual DbSet<SesionPractica> SesionPractica { get; set; }
        public virtual DbSet<SubPanel> SubPanel { get; set; }
        public virtual DbSet<TipoIdentidad> TipoIdentidad { get; set; }
        public virtual DbSet<TipoMaterial> TipoMaterial { get; set; }
        public virtual DbSet<XpobjectType> XpobjectType { get; set; }
        public virtual DbSet<XpweakReference> XpweakReference { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=tcp:ap-innovacion.database.windows.net,1433;Initial Catalog=KIRVIT_App;Persist Security Info=False;User ID=saTecna;Password=Alejo1padi123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acciones>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.CheckList)
                    .HasName("iCheckList_Acciones");

                entity.HasIndex(e => e.Etiqueta)
                    .HasName("iEtiqueta_Acciones");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Acciones");

                entity.HasIndex(e => e.Instrumento)
                    .HasName("iInstrumento_Acciones");

                entity.HasIndex(e => e.SubPanel)
                    .HasName("iSubPanel_Acciones");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Descripción).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.PilotoOcopiloto).HasColumnName("PilotoOCopiloto");

                entity.HasOne(d => d.CheckListNavigation)
                    .WithMany(p => p.Acciones)
                    .HasForeignKey(d => d.CheckList)
                    .HasConstraintName("FK_Acciones_CheckList");

                entity.HasOne(d => d.EtiquetaNavigation)
                    .WithMany(p => p.Acciones)
                    .HasForeignKey(d => d.Etiqueta)
                    .HasConstraintName("FK_Acciones_Etiqueta");

                entity.HasOne(d => d.InstrumentoNavigation)
                    .WithMany(p => p.Acciones)
                    .HasForeignKey(d => d.Instrumento)
                    .HasConstraintName("FK_Acciones_Instrumento");

                entity.HasOne(d => d.SubPanelNavigation)
                    .WithMany(p => p.Acciones)
                    .HasForeignKey(d => d.SubPanel)
                    .HasConstraintName("FK_Acciones_SubPanel");
            });

            modelBuilder.Entity<AreasAcademicas>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_AreasAcademicas");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Descripción).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Título).HasMaxLength(100);
            });

            modelBuilder.Entity<AuditDataItemPersistent>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.AuditedObject)
                    .HasName("iAuditedObject_AuditDataItemPersistent");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_AuditDataItemPersistent");

                entity.HasIndex(e => e.ModifiedOn)
                    .HasName("iModifiedOn_AuditDataItemPersistent");

                entity.HasIndex(e => e.NewObject)
                    .HasName("iNewObject_AuditDataItemPersistent");

                entity.HasIndex(e => e.OldObject)
                    .HasName("iOldObject_AuditDataItemPersistent");

                entity.HasIndex(e => e.OperationType)
                    .HasName("iOperationType_AuditDataItemPersistent");

                entity.HasIndex(e => e.UserName)
                    .HasName("iUserName_AuditDataItemPersistent");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.NewValue).HasMaxLength(1024);

                entity.Property(e => e.OldValue).HasMaxLength(1024);

                entity.Property(e => e.OperationType).HasMaxLength(100);

                entity.Property(e => e.PropertyName).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.HasOne(d => d.AuditedObjectNavigation)
                    .WithMany(p => p.AuditDataItemPersistent)
                    .HasForeignKey(d => d.AuditedObject)
                    .HasConstraintName("FK_AuditDataItemPersistent_AuditedObject");

                entity.HasOne(d => d.NewObjectNavigation)
                    .WithMany(p => p.AuditDataItemPersistentNewObjectNavigation)
                    .HasForeignKey(d => d.NewObject)
                    .HasConstraintName("FK_AuditDataItemPersistent_NewObject");

                entity.HasOne(d => d.OldObjectNavigation)
                    .WithMany(p => p.AuditDataItemPersistentOldObjectNavigation)
                    .HasForeignKey(d => d.OldObject)
                    .HasConstraintName("FK_AuditDataItemPersistent_OldObject");
            });

            modelBuilder.Entity<AuditedObjectWeakReference>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.DisplayName).HasMaxLength(250);

                entity.HasOne(d => d.O)
                    .WithOne(p => p.AuditedObjectWeakReference)
                    .HasForeignKey<AuditedObjectWeakReference>(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuditedObjectWeakReference_Oid");
            });

            modelBuilder.Entity<Certificaciones>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Certificaciones");

                entity.HasIndex(e => e.Persona)
                    .HasName("iPersona_Certificaciones");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.FechaCulminación).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Institución).HasMaxLength(100);

                entity.Property(e => e.Título).HasMaxLength(100);

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany(p => p.Certificaciones)
                    .HasForeignKey(d => d.Persona)
                    .HasConstraintName("FK_Certificaciones_Persona");
            });

            modelBuilder.Entity<CheckList>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_CheckList");

                entity.HasIndex(e => e.MateriaPráctica)
                    .HasName("iMateriaPráctica_CheckList");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Nota).HasMaxLength(100);

                entity.Property(e => e.Título).HasMaxLength(100);

                entity.HasOne(d => d.MateriaPrácticaNavigation)
                    .WithMany(p => p.CheckList)
                    .HasForeignKey(d => d.MateriaPráctica)
                    .HasConstraintName("FK_CheckList_MateriaPráctica");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Ciudad");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Departamento).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.NombreCiudad).HasMaxLength(100);

                entity.Property(e => e.País).HasMaxLength(100);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Curso");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Descripción).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Título).HasMaxLength(100);
            });

            modelBuilder.Entity<DashboardData>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_DashboardData");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Estado");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Descripción).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.NombreEstado).HasMaxLength(100);
            });

            modelBuilder.Entity<Etiqueta>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Etiqueta");

                entity.HasIndex(e => e.Instrumento)
                    .HasName("iInstrumento_Etiqueta");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.HasOne(d => d.InstrumentoNavigation)
                    .WithMany(p => p.Etiqueta)
                    .HasForeignKey(d => d.Instrumento)
                    .HasConstraintName("FK_Etiqueta_Instrumento");
            });

            modelBuilder.Entity<EvaluacionPractica>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.ChecklistEvaluado)
                    .HasName("iChecklistEvaluado_EvaluacionPractica");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_EvaluacionPractica");

                entity.HasIndex(e => e.SesiónPráctica)
                    .HasName("iSesiónPráctica_EvaluacionPractica");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.NoReporte).HasMaxLength(100);

                entity.HasOne(d => d.ChecklistEvaluadoNavigation)
                    .WithMany(p => p.EvaluacionPractica)
                    .HasForeignKey(d => d.ChecklistEvaluado)
                    .HasConstraintName("FK_EvaluacionPractica_ChecklistEvaluado");

                entity.HasOne(d => d.SesiónPrácticaNavigation)
                    .WithMany(p => p.EvaluacionPractica)
                    .HasForeignKey(d => d.SesiónPráctica)
                    .HasConstraintName("FK_EvaluacionPractica_SesiónPráctica");
            });

            modelBuilder.Entity<EvaluacionTeorica>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Estudiante)
                    .HasName("iEstudiante_EvaluacionTeorica");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_EvaluacionTeorica");

                entity.HasIndex(e => e.Materia)
                    .HasName("iMateria_EvaluacionTeorica");

                entity.HasIndex(e => e.RegistroInstalación)
                    .HasName("iRegistroInstalación_EvaluacionTeorica");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.NoReporte).HasMaxLength(100);

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.EvaluacionTeorica)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("FK_EvaluacionTeorica_Estudiante");

                entity.HasOne(d => d.MateriaNavigation)
                    .WithMany(p => p.EvaluacionTeorica)
                    .HasForeignKey(d => d.Materia)
                    .HasConstraintName("FK_EvaluacionTeorica_Materia");

                entity.HasOne(d => d.RegistroInstalaciónNavigation)
                    .WithMany(p => p.EvaluacionTeorica)
                    .HasForeignKey(d => d.RegistroInstalación)
                    .HasConstraintName("FK_EvaluacionTeorica_RegistroInstalación");
            });

            modelBuilder.Entity<FileData>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_FileData");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.FileName).HasMaxLength(260);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Size).HasColumnName("size");
            });

            modelBuilder.Entity<Grado>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Grado");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Código).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.TipoGrado).HasMaxLength(100);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.CursoAsociado)
                    .HasName("iCursoAsociado_Grupo");

                entity.HasIndex(e => e.EstadoCurso)
                    .HasName("iEstadoCurso_Grupo");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Grupo");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Título).HasMaxLength(100);

                entity.HasOne(d => d.CursoAsociadoNavigation)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.CursoAsociado)
                    .HasConstraintName("FK_Grupo_CursoAsociado");

                entity.HasOne(d => d.EstadoCursoNavigation)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.EstadoCurso)
                    .HasConstraintName("FK_Grupo_EstadoCurso");
            });

            modelBuilder.Entity<Hcategory>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("HCategory");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_HCategory");

                entity.HasIndex(e => e.Parent)
                    .HasName("iParent_HCategory");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .HasConstraintName("FK_HCategory_Parent");
            });

            modelBuilder.Entity<HistorialAcademico>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Curso)
                    .HasName("iCurso_HistorialAcademico");

                entity.HasIndex(e => e.EstadoMateria)
                    .HasName("iEstadoMateria_HistorialAcademico");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_HistorialAcademico");

                entity.HasIndex(e => e.Grupo)
                    .HasName("iGrupo_HistorialAcademico");

                entity.HasIndex(e => e.MateriaPractica)
                    .HasName("iMateriaPractica_HistorialAcademico");

                entity.HasIndex(e => e.MateriaTeóricas)
                    .HasName("iMateriaTeóricas_HistorialAcademico");

                entity.HasIndex(e => e.Persona)
                    .HasName("iPersona_HistorialAcademico");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.HistorialAcademico)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("FK_HistorialAcademico_Curso");

                entity.HasOne(d => d.EstadoMateriaNavigation)
                    .WithMany(p => p.HistorialAcademico)
                    .HasForeignKey(d => d.EstadoMateria)
                    .HasConstraintName("FK_HistorialAcademico_EstadoMateria");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.HistorialAcademico)
                    .HasForeignKey(d => d.Grupo)
                    .HasConstraintName("FK_HistorialAcademico_Grupo");

                entity.HasOne(d => d.MateriaPracticaNavigation)
                    .WithMany(p => p.HistorialAcademico)
                    .HasForeignKey(d => d.MateriaPractica)
                    .HasConstraintName("FK_HistorialAcademico_MateriaPractica");

                entity.HasOne(d => d.MateriaTeóricasNavigation)
                    .WithMany(p => p.HistorialAcademico)
                    .HasForeignKey(d => d.MateriaTeóricas)
                    .HasConstraintName("FK_HistorialAcademico_MateriaTeóricas");

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany(p => p.HistorialAcademico)
                    .HasForeignKey(d => d.Persona)
                    .HasConstraintName("FK_HistorialAcademico_Persona");
            });

            modelBuilder.Entity<Instalacion>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Ciudad)
                    .HasName("iCiudad_Instalacion");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Instalacion");

                entity.HasIndex(e => e.GradoComandante)
                    .HasName("iGradoComandante_Instalacion");

                entity.HasIndex(e => e.TipoIdentidad)
                    .HasName("iTipoIdentidad_Instalacion");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.CódigoAcceso).HasMaxLength(100);

                entity.Property(e => e.FechaActualización).HasColumnType("datetime");

                entity.Property(e => e.FechaBackup).HasColumnType("datetime");

                entity.Property(e => e.FechaInstalación).HasColumnType("datetime");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.NombreAbreviado).HasMaxLength(100);

                entity.Property(e => e.NombreComandante).HasMaxLength(100);

                entity.Property(e => e.NúmeroIdentidad).HasMaxLength(100);

                entity.Property(e => e.RutaBasesDeDatos).HasMaxLength(100);

                entity.Property(e => e.RutaCalibracion).HasMaxLength(100);

                entity.HasOne(d => d.CiudadNavigation)
                    .WithMany(p => p.Instalacion)
                    .HasForeignKey(d => d.Ciudad)
                    .HasConstraintName("FK_Instalacion_Ciudad");

                entity.HasOne(d => d.GradoComandanteNavigation)
                    .WithMany(p => p.Instalacion)
                    .HasForeignKey(d => d.GradoComandante)
                    .HasConstraintName("FK_Instalacion_GradoComandante");

                entity.HasOne(d => d.TipoIdentidadNavigation)
                    .WithMany(p => p.Instalacion)
                    .HasForeignKey(d => d.TipoIdentidad)
                    .HasConstraintName("FK_Instalacion_TipoIdentidad");
            });

            modelBuilder.Entity<Institución>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Ciudad)
                    .HasName("iCiudad_Institución");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Institución");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.HasOne(d => d.CiudadNavigation)
                    .WithMany(p => p.Institución)
                    .HasForeignKey(d => d.Ciudad)
                    .HasConstraintName("FK_Institución_Ciudad");
            });

            modelBuilder.Entity<Instrumento>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Instrumento");

                entity.HasIndex(e => e.Subpanel)
                    .HasName("iSubpanel_Instrumento");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.NombreInstrumento).HasMaxLength(100);

                entity.Property(e => e.Rango).HasMaxLength(100);

                entity.HasOne(d => d.SubpanelNavigation)
                    .WithMany(p => p.Instrumento)
                    .HasForeignKey(d => d.Subpanel)
                    .HasConstraintName("FK_Instrumento_Subpanel");
            });

            modelBuilder.Entity<KpiDefinition>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_KpiDefinition");

                entity.HasIndex(e => e.KpiInstance)
                    .HasName("iKpiInstance_KpiDefinition");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Changed).HasColumnType("datetime");

                entity.Property(e => e.ChangedOn).HasColumnType("datetime");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Range).HasMaxLength(100);

                entity.Property(e => e.RangeToCompare).HasMaxLength(100);

                entity.Property(e => e.SuppressedSeries).HasMaxLength(100);

                entity.HasOne(d => d.KpiInstanceNavigation)
                    .WithMany(p => p.KpiDefinitionNavigation)
                    .HasForeignKey(d => d.KpiInstance)
                    .HasConstraintName("FK_KpiDefinition_KpiInstance");
            });

            modelBuilder.Entity<KpiHistoryItem>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.KpiInstance)
                    .HasName("iKpiInstance_KpiHistoryItem");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.RangeEnd).HasColumnType("datetime");

                entity.Property(e => e.RangeStart).HasColumnType("datetime");

                entity.HasOne(d => d.KpiInstanceNavigation)
                    .WithMany(p => p.KpiHistoryItem)
                    .HasForeignKey(d => d.KpiInstance)
                    .HasConstraintName("FK_KpiHistoryItem_KpiInstance");
            });

            modelBuilder.Entity<KpiInstance>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_KpiInstance");

                entity.HasIndex(e => e.KpiDefinition)
                    .HasName("iKpiDefinition_KpiInstance");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.ForceMeasurementDateTime).HasColumnType("datetime");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.HasOne(d => d.KpiDefinition1)
                    .WithMany(p => p.KpiInstance1)
                    .HasForeignKey(d => d.KpiDefinition)
                    .HasConstraintName("FK_KpiInstance_KpiDefinition");
            });

            modelBuilder.Entity<KpiScorecard>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_KpiScorecard");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<KpiScorecardScorecardsKpiInstanceIndicators>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("KpiScorecardScorecards_KpiInstanceIndicators");

                entity.HasIndex(e => e.Indicators)
                    .HasName("iIndicators_KpiScorecardScorecards_KpiInstanceIndicators");

                entity.HasIndex(e => e.Scorecards)
                    .HasName("iScorecards_KpiScorecardScorecards_KpiInstanceIndicators");

                entity.HasIndex(e => new { e.Indicators, e.Scorecards })
                    .HasName("iIndicatorsScorecards_KpiScorecardScorecards_KpiInstanceIndicators")
                    .IsUnique();

                entity.Property(e => e.Oid)
                    .HasColumnName("OID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IndicatorsNavigation)
                    .WithMany(p => p.KpiScorecardScorecardsKpiInstanceIndicators)
                    .HasForeignKey(d => d.Indicators)
                    .HasConstraintName("FK_KpiScorecardScorecards_KpiInstanceIndicators_Indicators");

                entity.HasOne(d => d.ScorecardsNavigation)
                    .WithMany(p => p.KpiScorecardScorecardsKpiInstanceIndicators)
                    .HasForeignKey(d => d.Scorecards)
                    .HasConstraintName("FK_KpiScorecardScorecards_KpiInstanceIndicators_Scorecards");
            });

            modelBuilder.Entity<LabelSignalsEtiquetas>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("Label_Signals_Etiquetas");

                entity.HasIndex(e => e.Etiquetas)
                    .HasName("iEtiquetas_Label_Signals_Etiquetas");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Label_Signals_Etiquetas");

                entity.HasIndex(e => e.SenalElectronica)
                    .HasName("iSenalElectronica_Label_Signals_Etiquetas");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Valor).HasMaxLength(100);

                entity.HasOne(d => d.EtiquetasNavigation)
                    .WithMany(p => p.LabelSignalsEtiquetas)
                    .HasForeignKey(d => d.Etiquetas)
                    .HasConstraintName("FK_Label_Signals_Etiquetas_Etiquetas");

                entity.HasOne(d => d.SenalElectronicaNavigation)
                    .WithMany(p => p.LabelSignalsEtiquetas)
                    .HasForeignKey(d => d.SenalElectronica)
                    .HasConstraintName("FK_Label_Signals_Etiquetas_SenalElectronica");
            });

            modelBuilder.Entity<MaterialApoyo>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Archivo)
                    .HasName("iArchivo_MaterialApoyo");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_MaterialApoyo");

                entity.HasIndex(e => e.TipoMaterial)
                    .HasName("iTipoMaterial_MaterialApoyo");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(100);

                entity.HasOne(d => d.ArchivoNavigation)
                    .WithMany(p => p.MaterialApoyo)
                    .HasForeignKey(d => d.Archivo)
                    .HasConstraintName("FK_MaterialApoyo_Archivo");

                entity.HasOne(d => d.TipoMaterialNavigation)
                    .WithMany(p => p.MaterialApoyo)
                    .HasForeignKey(d => d.TipoMaterial)
                    .HasConstraintName("FK_MaterialApoyo_TipoMaterial");
            });

            modelBuilder.Entity<MateriasPrácticas>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.AreaAcademica)
                    .HasName("iAreaAcademica_MateriasPrácticas");

                entity.HasIndex(e => e.Contenido)
                    .HasName("iContenido_MateriasPrácticas");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_MateriasPrácticas");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Título).HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AreaAcademicaNavigation)
                    .WithMany(p => p.MateriasPrácticas)
                    .HasForeignKey(d => d.AreaAcademica)
                    .HasConstraintName("FK_MateriasPrácticas_AreaAcademica");

                entity.HasOne(d => d.ContenidoNavigation)
                    .WithMany(p => p.MateriasPrácticas)
                    .HasForeignKey(d => d.Contenido)
                    .HasConstraintName("FK_MateriasPrácticas_Contenido");
            });

            modelBuilder.Entity<MateriasPrácticasMateriasPrácticasCursoCursos>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("MateriasPrácticasMateriasPrácticas_CursoCursos");

                entity.HasIndex(e => e.Cursos)
                    .HasName("iCursos_MateriasPrácticasMateriasPrácticas_CursoCursos");

                entity.HasIndex(e => e.MateriasPrácticas)
                    .HasName("iMateriasPrácticas_MateriasPrácticasMateriasPrácticas_CursoCursos");

                entity.HasIndex(e => new { e.Cursos, e.MateriasPrácticas })
                    .HasName("iCursosMateriasPrácticas_MateriasPrácticasMateriasPrácticas_CursoCursos")
                    .IsUnique();

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.HasOne(d => d.CursosNavigation)
                    .WithMany(p => p.MateriasPrácticasMateriasPrácticasCursoCursos)
                    .HasForeignKey(d => d.Cursos)
                    .HasConstraintName("FK_MateriasPrácticasMateriasPrácticas_CursoCursos_Cursos");

                entity.HasOne(d => d.MateriasPrácticasNavigation)
                    .WithMany(p => p.MateriasPrácticasMateriasPrácticasCursoCursos)
                    .HasForeignKey(d => d.MateriasPrácticas)
                    .HasConstraintName("FK_MateriasPrácticasMateriasPrácticas_CursoCursos_MateriasPrácticas");
            });

            modelBuilder.Entity<MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("MateriasPrácticasMateriasPrácticas_MaterialApoyoMaterialApoyos");

                entity.HasIndex(e => e.MaterialApoyos)
                    .HasName("iMaterialApoyos_MateriasPrácticasMateriasPrácticas_MaterialApoyoMaterialApoyos");

                entity.HasIndex(e => e.MateriasPrácticas)
                    .HasName("iMateriasPrácticas_MateriasPrácticasMateriasPrácticas_MaterialApoyoMaterialApoyos");

                entity.HasIndex(e => new { e.MaterialApoyos, e.MateriasPrácticas })
                    .HasName("iMaterialApoyosMateriasPrácticas_MateriasPrácticasMateriasPrácticas_MaterialApoyoMaterialApoyos")
                    .IsUnique();

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.HasOne(d => d.MaterialApoyosNavigation)
                    .WithMany(p => p.MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos)
                    .HasForeignKey(d => d.MaterialApoyos)
                    .HasConstraintName("FK_MateriasPrácticasMateriasPrácticas_MaterialApoyoMaterialApoyos_MaterialApoyos");

                entity.HasOne(d => d.MateriasPrácticasNavigation)
                    .WithMany(p => p.MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos)
                    .HasForeignKey(d => d.MateriasPrácticas)
                    .HasConstraintName("FK_MateriasPrácticasMateriasPrácticas_MaterialApoyoMaterialApoyos_MateriasPrácticas");
            });

            modelBuilder.Entity<MateriasTeóricas>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.AreaAcademica)
                    .HasName("iAreaAcademica_MateriasTeóricas");

                entity.HasIndex(e => e.Contenido)
                    .HasName("iContenido_MateriasTeóricas");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_MateriasTeóricas");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Título).HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AreaAcademicaNavigation)
                    .WithMany(p => p.MateriasTeóricas)
                    .HasForeignKey(d => d.AreaAcademica)
                    .HasConstraintName("FK_MateriasTeóricas_AreaAcademica");

                entity.HasOne(d => d.ContenidoNavigation)
                    .WithMany(p => p.MateriasTeóricas)
                    .HasForeignKey(d => d.Contenido)
                    .HasConstraintName("FK_MateriasTeóricas_Contenido");
            });

            modelBuilder.Entity<MateriasTeóricasMateriasTeóricasCursoCursos>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("MateriasTeóricasMateriasTeóricas_CursoCursos");

                entity.HasIndex(e => e.Cursos)
                    .HasName("iCursos_MateriasTeóricasMateriasTeóricas_CursoCursos");

                entity.HasIndex(e => e.MateriasTeóricas)
                    .HasName("iMateriasTeóricas_MateriasTeóricasMateriasTeóricas_CursoCursos");

                entity.HasIndex(e => new { e.Cursos, e.MateriasTeóricas })
                    .HasName("iCursosMateriasTeóricas_MateriasTeóricasMateriasTeóricas_CursoCursos")
                    .IsUnique();

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.HasOne(d => d.CursosNavigation)
                    .WithMany(p => p.MateriasTeóricasMateriasTeóricasCursoCursos)
                    .HasForeignKey(d => d.Cursos)
                    .HasConstraintName("FK_MateriasTeóricasMateriasTeóricas_CursoCursos_Cursos");

                entity.HasOne(d => d.MateriasTeóricasNavigation)
                    .WithMany(p => p.MateriasTeóricasMateriasTeóricasCursoCursos)
                    .HasForeignKey(d => d.MateriasTeóricas)
                    .HasConstraintName("FK_MateriasTeóricasMateriasTeóricas_CursoCursos_MateriasTeóricas");
            });

            modelBuilder.Entity<MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("MateriasTeóricasMateriasTeóricas_MaterialApoyoMaterialApoyos");

                entity.HasIndex(e => e.MaterialApoyos)
                    .HasName("iMaterialApoyos_MateriasTeóricasMateriasTeóricas_MaterialApoyoMaterialApoyos");

                entity.HasIndex(e => e.MateriasTeóricas)
                    .HasName("iMateriasTeóricas_MateriasTeóricasMateriasTeóricas_MaterialApoyoMaterialApoyos");

                entity.HasIndex(e => new { e.MaterialApoyos, e.MateriasTeóricas })
                    .HasName("iMaterialApoyosMateriasTeóricas_MateriasTeóricasMateriasTeóricas_MaterialApoyoMaterialApoyos")
                    .IsUnique();

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.HasOne(d => d.MaterialApoyosNavigation)
                    .WithMany(p => p.MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos)
                    .HasForeignKey(d => d.MaterialApoyos)
                    .HasConstraintName("FK_MateriasTeóricasMateriasTeóricas_MaterialApoyoMaterialApoyos_MaterialApoyos");

                entity.HasOne(d => d.MateriasTeóricasNavigation)
                    .WithMany(p => p.MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos)
                    .HasForeignKey(d => d.MateriasTeóricas)
                    .HasConstraintName("FK_MateriasTeóricasMateriasTeóricas_MaterialApoyoMaterialApoyos_MateriasTeóricas");
            });

            modelBuilder.Entity<ModelDifference>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_ModelDifference");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.ContextId).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.UserId).HasMaxLength(100);
            });

            modelBuilder.Entity<ModelDifferenceAspect>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_ModelDifferenceAspect");

                entity.HasIndex(e => e.Owner)
                    .HasName("iOwner_ModelDifferenceAspect");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.ModelDifferenceAspect)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_ModelDifferenceAspect_Owner");
            });

            modelBuilder.Entity<ParametroInicial>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Etiqueta)
                    .HasName("iEtiqueta_ParametroInicial");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_ParametroInicial");

                entity.HasIndex(e => e.Instrumento)
                    .HasName("iInstrumento_ParametroInicial");

                entity.HasIndex(e => e.MateriasPracticas)
                    .HasName("iMateriasPracticas_ParametroInicial");

                entity.HasIndex(e => e.SubPanel)
                    .HasName("iSubPanel_ParametroInicial");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Valor).HasMaxLength(100);

                entity.HasOne(d => d.EtiquetaNavigation)
                    .WithMany(p => p.ParametroInicial)
                    .HasForeignKey(d => d.Etiqueta)
                    .HasConstraintName("FK_ParametroInicial_Etiqueta");

                entity.HasOne(d => d.InstrumentoNavigation)
                    .WithMany(p => p.ParametroInicial)
                    .HasForeignKey(d => d.Instrumento)
                    .HasConstraintName("FK_ParametroInicial_Instrumento");

                entity.HasOne(d => d.MateriasPracticasNavigation)
                    .WithMany(p => p.ParametroInicial)
                    .HasForeignKey(d => d.MateriasPracticas)
                    .HasConstraintName("FK_ParametroInicial_MateriasPracticas");

                entity.HasOne(d => d.SubPanelNavigation)
                    .WithMany(p => p.ParametroInicial)
                    .HasForeignKey(d => d.SubPanel)
                    .HasConstraintName("FK_ParametroInicial_SubPanel");
            });

            modelBuilder.Entity<PermissionPolicyActionPermissionObject>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_PermissionPolicyActionPermissionObject");

                entity.HasIndex(e => e.Role)
                    .HasName("iRole_PermissionPolicyActionPermissionObject");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.ActionId).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.PermissionPolicyActionPermissionObject)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_PermissionPolicyActionPermissionObject_Role");
            });

            modelBuilder.Entity<PermissionPolicyMemberPermissionsObject>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_PermissionPolicyMemberPermissionsObject");

                entity.HasIndex(e => e.TypePermissionObject)
                    .HasName("iTypePermissionObject_PermissionPolicyMemberPermissionsObject");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.HasOne(d => d.TypePermissionObjectNavigation)
                    .WithMany(p => p.PermissionPolicyMemberPermissionsObject)
                    .HasForeignKey(d => d.TypePermissionObject)
                    .HasConstraintName("FK_PermissionPolicyMemberPermissionsObject_TypePermissionObject");
            });

            modelBuilder.Entity<PermissionPolicyNavigationPermissionsObject>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_PermissionPolicyNavigationPermissionsObject");

                entity.HasIndex(e => e.Role)
                    .HasName("iRole_PermissionPolicyNavigationPermissionsObject");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.PermissionPolicyNavigationPermissionsObject)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_PermissionPolicyNavigationPermissionsObject_Role");
            });

            modelBuilder.Entity<PermissionPolicyObjectPermissionsObject>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_PermissionPolicyObjectPermissionsObject");

                entity.HasIndex(e => e.TypePermissionObject)
                    .HasName("iTypePermissionObject_PermissionPolicyObjectPermissionsObject");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.HasOne(d => d.TypePermissionObjectNavigation)
                    .WithMany(p => p.PermissionPolicyObjectPermissionsObject)
                    .HasForeignKey(d => d.TypePermissionObject)
                    .HasConstraintName("FK_PermissionPolicyObjectPermissionsObject_TypePermissionObject");
            });

            modelBuilder.Entity<PermissionPolicyRole>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_PermissionPolicyRole");

                entity.HasIndex(e => e.ObjectType)
                    .HasName("iObjectType_PermissionPolicyRole");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.ObjectTypeNavigation)
                    .WithMany(p => p.PermissionPolicyRole)
                    .HasForeignKey(d => d.ObjectType)
                    .HasConstraintName("FK_PermissionPolicyRole_ObjectType");
            });

            modelBuilder.Entity<PermissionPolicyTypePermissionsObject>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_PermissionPolicyTypePermissionsObject");

                entity.HasIndex(e => e.Role)
                    .HasName("iRole_PermissionPolicyTypePermissionsObject");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.PermissionPolicyTypePermissionsObject)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_PermissionPolicyTypePermissionsObject_Role");
            });

            modelBuilder.Entity<PermissionPolicyUser>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_PermissionPolicyUser");

                entity.HasIndex(e => e.ObjectType)
                    .HasName("iObjectType_PermissionPolicyUser");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.HasOne(d => d.ObjectTypeNavigation)
                    .WithMany(p => p.PermissionPolicyUser)
                    .HasForeignKey(d => d.ObjectType)
                    .HasConstraintName("FK_PermissionPolicyUser_ObjectType");
            });

            modelBuilder.Entity<PermissionPolicyUserUsersPermissionPolicyRoleRoles>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("PermissionPolicyUserUsers_PermissionPolicyRoleRoles");

                entity.HasIndex(e => e.Roles)
                    .HasName("iRoles_PermissionPolicyUserUsers_PermissionPolicyRoleRoles");

                entity.HasIndex(e => e.Users)
                    .HasName("iUsers_PermissionPolicyUserUsers_PermissionPolicyRoleRoles");

                entity.HasIndex(e => new { e.Roles, e.Users })
                    .HasName("iRolesUsers_PermissionPolicyUserUsers_PermissionPolicyRoleRoles")
                    .IsUnique();

                entity.Property(e => e.Oid)
                    .HasColumnName("OID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.RolesNavigation)
                    .WithMany(p => p.PermissionPolicyUserUsersPermissionPolicyRoleRoles)
                    .HasForeignKey(d => d.Roles)
                    .HasConstraintName("FK_PermissionPolicyUserUsers_PermissionPolicyRoleRoles_Roles");

                entity.HasOne(d => d.UsersNavigation)
                    .WithMany(p => p.PermissionPolicyUserUsersPermissionPolicyRoleRoles)
                    .HasForeignKey(d => d.Users)
                    .HasConstraintName("FK_PermissionPolicyUserUsers_PermissionPolicyRoleRoles_Users");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.CiudadOrigen)
                    .HasName("iCiudadOrigen_Persona");

                entity.HasIndex(e => e.CiudadResidencia)
                    .HasName("iCiudadResidencia_Persona");

                entity.HasIndex(e => e.Grado)
                    .HasName("iGrado_Persona");

                entity.HasIndex(e => e.Institución)
                    .HasName("iInstitución_Persona");

                entity.HasIndex(e => e.TipoIdentidad)
                    .HasName("iTipoIdentidad_Persona");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Apellidos).HasMaxLength(100);

                entity.Property(e => e.Celular).HasMaxLength(100);

                entity.Property(e => e.CorreoElectrónico).HasMaxLength(100);

                entity.Property(e => e.Dirección).HasMaxLength(100);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombres).HasMaxLength(100);

                entity.Property(e => e.NúmeroIdentidad).HasMaxLength(100);

                entity.Property(e => e.Teléfono).HasMaxLength(100);

                entity.HasOne(d => d.CiudadOrigenNavigation)
                    .WithMany(p => p.PersonaCiudadOrigenNavigation)
                    .HasForeignKey(d => d.CiudadOrigen)
                    .HasConstraintName("FK_Persona_CiudadOrigen");

                entity.HasOne(d => d.CiudadResidenciaNavigation)
                    .WithMany(p => p.PersonaCiudadResidenciaNavigation)
                    .HasForeignKey(d => d.CiudadResidencia)
                    .HasConstraintName("FK_Persona_CiudadResidencia");

                entity.HasOne(d => d.GradoNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.Grado)
                    .HasConstraintName("FK_Persona_Grado");

                entity.HasOne(d => d.InstituciónNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.Institución)
                    .HasConstraintName("FK_Persona_Institución");

                entity.HasOne(d => d.O)
                    .WithOne(p => p.Persona)
                    .HasForeignKey<Persona>(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Oid");

                entity.HasOne(d => d.TipoIdentidadNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.TipoIdentidad)
                    .HasConstraintName("FK_Persona_TipoIdentidad");
            });

            modelBuilder.Entity<PersonaEstudiantesGrupoGruposEstudiantes>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("PersonaEstudiantes_GrupoGruposEstudiantes");

                entity.HasIndex(e => e.Estudiantes)
                    .HasName("iEstudiantes_PersonaEstudiantes_GrupoGruposEstudiantes");

                entity.HasIndex(e => e.GruposEstudiantes)
                    .HasName("iGruposEstudiantes_PersonaEstudiantes_GrupoGruposEstudiantes");

                entity.HasIndex(e => new { e.GruposEstudiantes, e.Estudiantes })
                    .HasName("iGruposEstudiantesEstudiantes_PersonaEstudiantes_GrupoGruposEstudiantes")
                    .IsUnique();

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.HasOne(d => d.EstudiantesNavigation)
                    .WithMany(p => p.PersonaEstudiantesGrupoGruposEstudiantes)
                    .HasForeignKey(d => d.Estudiantes)
                    .HasConstraintName("FK_PersonaEstudiantes_GrupoGruposEstudiantes_Estudiantes");

                entity.HasOne(d => d.GruposEstudiantesNavigation)
                    .WithMany(p => p.PersonaEstudiantesGrupoGruposEstudiantes)
                    .HasForeignKey(d => d.GruposEstudiantes)
                    .HasConstraintName("FK_PersonaEstudiantes_GrupoGruposEstudiantes_GruposEstudiantes");
            });

            modelBuilder.Entity<PersonaInstructoresGrupoGruposInstructores>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("PersonaInstructores_GrupoGruposInstructores");

                entity.HasIndex(e => e.GruposInstructores)
                    .HasName("iGruposInstructores_PersonaInstructores_GrupoGruposInstructores");

                entity.HasIndex(e => e.Instructores)
                    .HasName("iInstructores_PersonaInstructores_GrupoGruposInstructores");

                entity.HasIndex(e => new { e.GruposInstructores, e.Instructores })
                    .HasName("iGruposInstructoresInstructores_PersonaInstructores_GrupoGruposInstructores")
                    .IsUnique();

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.HasOne(d => d.GruposInstructoresNavigation)
                    .WithMany(p => p.PersonaInstructoresGrupoGruposInstructores)
                    .HasForeignKey(d => d.GruposInstructores)
                    .HasConstraintName("FK_PersonaInstructores_GrupoGruposInstructores_GruposInstructores");

                entity.HasOne(d => d.InstructoresNavigation)
                    .WithMany(p => p.PersonaInstructoresGrupoGruposInstructores)
                    .HasForeignKey(d => d.Instructores)
                    .HasConstraintName("FK_PersonaInstructores_GrupoGruposInstructores_Instructores");
            });

            modelBuilder.Entity<PuntosCalibracionInstrumentos>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_PuntosCalibracionInstrumentos");

                entity.HasIndex(e => e.Señal)
                    .HasName("iSeñal_PuntosCalibracionInstrumentos");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.FechaCalibracion).HasColumnType("datetime");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.NombreOperador).HasMaxLength(100);

                entity.Property(e => e.Valor).HasMaxLength(100);

                entity.Property(e => e.ValorPunto0Min).HasColumnName("ValorPunto_0_MIN");

                entity.Property(e => e.ValorPunto10).HasColumnName("ValorPunto_10");

                entity.Property(e => e.ValorPunto100).HasColumnName("ValorPunto_100");

                entity.Property(e => e.ValorPunto110).HasColumnName("ValorPunto_110");

                entity.Property(e => e.ValorPunto120).HasColumnName("ValorPunto_120");

                entity.Property(e => e.ValorPunto130).HasColumnName("ValorPunto_130");

                entity.Property(e => e.ValorPunto140).HasColumnName("ValorPunto_140");

                entity.Property(e => e.ValorPunto150).HasColumnName("ValorPunto_150");

                entity.Property(e => e.ValorPunto160).HasColumnName("ValorPunto_160");

                entity.Property(e => e.ValorPunto170).HasColumnName("ValorPunto_170");

                entity.Property(e => e.ValorPunto180).HasColumnName("ValorPunto_180");

                entity.Property(e => e.ValorPunto190).HasColumnName("ValorPunto_190");

                entity.Property(e => e.ValorPunto20).HasColumnName("ValorPunto_20");

                entity.Property(e => e.ValorPunto200).HasColumnName("ValorPunto_200");

                entity.Property(e => e.ValorPunto210).HasColumnName("ValorPunto_210");

                entity.Property(e => e.ValorPunto220).HasColumnName("ValorPunto_220");

                entity.Property(e => e.ValorPunto230).HasColumnName("ValorPunto_230");

                entity.Property(e => e.ValorPunto240).HasColumnName("ValorPunto_240");

                entity.Property(e => e.ValorPunto250).HasColumnName("ValorPunto_250");

                entity.Property(e => e.ValorPunto260).HasColumnName("ValorPunto_260");

                entity.Property(e => e.ValorPunto270).HasColumnName("ValorPunto_270");

                entity.Property(e => e.ValorPunto280).HasColumnName("ValorPunto_280");

                entity.Property(e => e.ValorPunto290).HasColumnName("ValorPunto_290");

                entity.Property(e => e.ValorPunto30).HasColumnName("ValorPunto_30");

                entity.Property(e => e.ValorPunto300).HasColumnName("ValorPunto_300");

                entity.Property(e => e.ValorPunto310).HasColumnName("ValorPunto_310");

                entity.Property(e => e.ValorPunto320).HasColumnName("ValorPunto_320");

                entity.Property(e => e.ValorPunto330).HasColumnName("ValorPunto_330");

                entity.Property(e => e.ValorPunto340).HasColumnName("ValorPunto_340");

                entity.Property(e => e.ValorPunto350).HasColumnName("ValorPunto_350");

                entity.Property(e => e.ValorPunto360Max).HasColumnName("ValorPunto_360_MAX");

                entity.Property(e => e.ValorPunto40).HasColumnName("ValorPunto_40");

                entity.Property(e => e.ValorPunto50).HasColumnName("ValorPunto_50");

                entity.Property(e => e.ValorPunto60).HasColumnName("ValorPunto_60");

                entity.Property(e => e.ValorPunto70).HasColumnName("ValorPunto_70");

                entity.Property(e => e.ValorPunto80).HasColumnName("ValorPunto_80");

                entity.Property(e => e.ValorPunto90).HasColumnName("ValorPunto_90");

                entity.HasOne(d => d.SeñalNavigation)
                    .WithMany(p => p.PuntosCalibracionInstrumentos)
                    .HasForeignKey(d => d.Señal)
                    .HasConstraintName("FK_PuntosCalibracionInstrumentos_Señal");
            });

            modelBuilder.Entity<Reaccion>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Reaccion");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            });

            modelBuilder.Entity<Reacciones>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Acciones)
                    .HasName("iAcciones_Reacciones");

                entity.HasIndex(e => e.Etiqueta)
                    .HasName("iEtiqueta_Reacciones");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_Reacciones");

                entity.HasIndex(e => e.Instrumento)
                    .HasName("iInstrumento_Reacciones");

                entity.HasIndex(e => e.MaterialApoyo)
                    .HasName("iMaterialApoyo_Reacciones");

                entity.HasIndex(e => e.SubPanel)
                    .HasName("iSubPanel_Reacciones");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.NombreReaccion).HasMaxLength(100);

                entity.HasOne(d => d.AccionesNavigation)
                    .WithMany(p => p.Reacciones)
                    .HasForeignKey(d => d.Acciones)
                    .HasConstraintName("FK_Reacciones_Acciones");

                entity.HasOne(d => d.EtiquetaNavigation)
                    .WithMany(p => p.Reacciones)
                    .HasForeignKey(d => d.Etiqueta)
                    .HasConstraintName("FK_Reacciones_Etiqueta");

                entity.HasOne(d => d.InstrumentoNavigation)
                    .WithMany(p => p.Reacciones)
                    .HasForeignKey(d => d.Instrumento)
                    .HasConstraintName("FK_Reacciones_Instrumento");

                entity.HasOne(d => d.MaterialApoyoNavigation)
                    .WithMany(p => p.Reacciones)
                    .HasForeignKey(d => d.MaterialApoyo)
                    .HasConstraintName("FK_Reacciones_MaterialApoyo");

                entity.HasOne(d => d.SubPanelNavigation)
                    .WithMany(p => p.Reacciones)
                    .HasForeignKey(d => d.SubPanel)
                    .HasConstraintName("FK_Reacciones_SubPanel");
            });

            modelBuilder.Entity<ReportDataV2>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_ReportDataV2");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ObjectTypeName).HasMaxLength(512);

                entity.Property(e => e.ParametersObjectTypeName).HasMaxLength(512);

                entity.Property(e => e.PredefinedReportType).HasMaxLength(512);
            });

            modelBuilder.Entity<SenalElectronica>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_SenalElectronica");

                entity.HasIndex(e => e.Instrumento)
                    .HasName("iInstrumento_SenalElectronica");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Board).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(100);

                entity.Property(e => e.Io).HasColumnName("IO");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.HasOne(d => d.InstrumentoNavigation)
                    .WithMany(p => p.SenalElectronica)
                    .HasForeignKey(d => d.Instrumento)
                    .HasConstraintName("FK_SenalElectronica_Instrumento");
            });

            modelBuilder.Entity<SesionPractica>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Copiloto)
                    .HasName("iCopiloto_SesionPractica");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_SesionPractica");

                entity.HasIndex(e => e.IngenieroDeVuelo)
                    .HasName("iIngenieroDeVuelo_SesionPractica");

                entity.HasIndex(e => e.Instructor)
                    .HasName("iInstructor_SesionPractica");

                entity.HasIndex(e => e.MateriaPractica)
                    .HasName("iMateriaPractica_SesionPractica");

                entity.HasIndex(e => e.Piloto)
                    .HasName("iPiloto_SesionPractica");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Ingeniero).HasColumnType("datetime");

                entity.HasOne(d => d.CopilotoNavigation)
                    .WithMany(p => p.SesionPracticaCopilotoNavigation)
                    .HasForeignKey(d => d.Copiloto)
                    .HasConstraintName("FK_SesionPractica_Copiloto");

                entity.HasOne(d => d.IngenieroDeVueloNavigation)
                    .WithMany(p => p.SesionPracticaIngenieroDeVueloNavigation)
                    .HasForeignKey(d => d.IngenieroDeVuelo)
                    .HasConstraintName("FK_SesionPractica_IngenieroDeVuelo");

                entity.HasOne(d => d.InstructorNavigation)
                    .WithMany(p => p.SesionPracticaInstructorNavigation)
                    .HasForeignKey(d => d.Instructor)
                    .HasConstraintName("FK_SesionPractica_Instructor");

                entity.HasOne(d => d.MateriaPracticaNavigation)
                    .WithMany(p => p.SesionPractica)
                    .HasForeignKey(d => d.MateriaPractica)
                    .HasConstraintName("FK_SesionPractica_MateriaPractica");

                entity.HasOne(d => d.PilotoNavigation)
                    .WithMany(p => p.SesionPracticaPilotoNavigation)
                    .HasForeignKey(d => d.Piloto)
                    .HasConstraintName("FK_SesionPractica_Piloto");
            });

            modelBuilder.Entity<SubPanel>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_SubPanel");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.NombrePanelPrincipal).HasMaxLength(100);

                entity.Property(e => e.NombreSubpanel).HasMaxLength(100);
            });

            modelBuilder.Entity<TipoIdentidad>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_TipoIdentidad");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Abreviatura).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<TipoMaterial>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_TipoMaterial");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Abreviatura).HasMaxLength(100);

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<XpobjectType>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("XPObjectType");

                entity.HasIndex(e => e.TypeName)
                    .HasName("iTypeName_XPObjectType")
                    .IsUnique();

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.AssemblyName).HasMaxLength(254);

                entity.Property(e => e.TypeName).HasMaxLength(254);
            });

            modelBuilder.Entity<XpweakReference>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("XPWeakReference");

                entity.HasIndex(e => e.Gcrecord)
                    .HasName("iGCRecord_XPWeakReference");

                entity.HasIndex(e => e.ObjectType)
                    .HasName("iObjectType_XPWeakReference");

                entity.HasIndex(e => e.TargetType)
                    .HasName("iTargetType_XPWeakReference");

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.TargetKey).HasMaxLength(100);

                entity.HasOne(d => d.ObjectTypeNavigation)
                    .WithMany(p => p.XpweakReferenceObjectTypeNavigation)
                    .HasForeignKey(d => d.ObjectType)
                    .HasConstraintName("FK_XPWeakReference_ObjectType");

                entity.HasOne(d => d.TargetTypeNavigation)
                    .WithMany(p => p.XpweakReferenceTargetTypeNavigation)
                    .HasForeignKey(d => d.TargetType)
                    .HasConstraintName("FK_XPWeakReference_TargetType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
